using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskWindow : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraCanvas;
    [SerializeField] private Toggle[] ConditionsCheckMarks;
    [SerializeField] private TMP_Text TaskName;
    [SerializeField] private AudioSource audioSource;
    public Task ActiveTask;
    private bool cameraCanvasActive = false, opened = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !opened)
        {
            openTaskWindow();
            opened = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && opened)
        {
            closeTaskWindow();
            opened = false;
        }
        if(ActiveTask != null)
        {
            if (ActiveTask.taskConditionsCount == 1)
            {
                if(ActiveTask.TaskConditions[1] == "true")
                {
                    ActiveTask.TaskCompleted = true;
                    if (ActiveTask.Taskname == "Зашифрованный")
                    {
                        player.GetComponent<IntroScene>().endOfGame = true;
                    }
                    ActiveTask = null;
                    audioSource.Play();
                    
                }
            }
            else if(ActiveTask.taskConditionsCount == 2)
            {
                if (ActiveTask.TaskConditions[1] == "true" && ActiveTask.TaskConditions[3] == "true")
                {
                    ActiveTask.TaskCompleted = true;
                    ActiveTask = null;
                    audioSource.Play();
                }
            }
            else if (ActiveTask.taskConditionsCount == 3)
            {
                if (ActiveTask.TaskConditions[1] == "true" && ActiveTask.TaskConditions[3] == "true" && ActiveTask.TaskConditions[5] == "true")
                {
                    ActiveTask.TaskCompleted = true;
                    ActiveTask = null;
                    audioSource.Play();
                }
            }
            else if (ActiveTask.taskConditionsCount == 4)
            {
                if (ActiveTask.TaskConditions[1] == "true" && ActiveTask.TaskConditions[3] == "true" && ActiveTask.TaskConditions[5] == "true" && ActiveTask.TaskConditions[7] == "true")
                {
                    ActiveTask.TaskCompleted = true;
                    ActiveTask = null;
                    audioSource.Play();
                }
            }
        }
    }
    public void openTaskWindow()
    {
        UpdateTasks();
        canvas.SetActive(true);
        player.GetComponent<MoveControl>().isActing = true;
        if (cameraCanvas.active)
        {
            cameraCanvasActive = true;
            cameraCanvas.SetActive(false);
        }
        Cursor.visible = true;
    }
    public void closeTaskWindow()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<MoveControl>().isActing = false;
        if(cameraCanvasActive)
        {
            cameraCanvas.SetActive(true);
            cameraCanvasActive = false;
        }
        Cursor.visible = false;
    }

    [System.Obsolete]
    public void UpdateTasks()
    {
        if (ActiveTask != null)
        {
            switch (ActiveTask.taskConditionsCount)
            {
                case 1:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(false);
                    ConditionsCheckMarks[2].gameObject.SetActive(false);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[1] == "true");
                    break;
                case 2:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(false);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[2];
                    ConditionsCheckMarks[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[1] == "true");
                    ConditionsCheckMarks[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[3] == "true");
                    break;
                case 3:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(true);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[2];
                    ConditionsCheckMarks[2].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[4];
                    ConditionsCheckMarks[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[1] == "true");
                    ConditionsCheckMarks[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[3] == "true");
                    ConditionsCheckMarks[2].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[5] == "true");
                    break;
                case 4:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(true);
                    ConditionsCheckMarks[3].gameObject.SetActive(true);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[2];
                    ConditionsCheckMarks[2].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[4];
                    ConditionsCheckMarks[3].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[6];
                    ConditionsCheckMarks[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[1] == "true");
                    ConditionsCheckMarks[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[3] == "true");
                    ConditionsCheckMarks[2].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[5] == "true");
                    ConditionsCheckMarks[3].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(ActiveTask.TaskConditions[7] == "true");
                    break;
            }
            if (ActiveTask != null)
            {
                TaskName.text = ActiveTask.Taskname + ':';
            }
        }
        else
        {
            foreach(Toggle checkMark in ConditionsCheckMarks)
            {
                checkMark.gameObject.SetActive(false);
            }
            TaskName.text = "Нет активных заданий";
        }
        Time.timeScale = 0f;
    }
}
