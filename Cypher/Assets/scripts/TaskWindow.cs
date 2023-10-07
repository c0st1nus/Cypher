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
        Time.timeScale = 0f;
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
    public void UpdateTasks()
    {
        if(ActiveTask != null)
        {
            switch (ActiveTask.taskConditionsCount)
            {
                case 1:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(false);
                    ConditionsCheckMarks[2].gameObject.SetActive(false);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    break;
                case 2:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(false);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[1];
                    break;
                case 3:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(true);
                    ConditionsCheckMarks[3].gameObject.SetActive(false);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[1];
                    ConditionsCheckMarks[2].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[2];
                    break;
                case 4:
                    ConditionsCheckMarks[0].gameObject.SetActive(true);
                    ConditionsCheckMarks[1].gameObject.SetActive(true);
                    ConditionsCheckMarks[2].gameObject.SetActive(true);
                    ConditionsCheckMarks[3].gameObject.SetActive(true);
                    ConditionsCheckMarks[0].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[0];
                    ConditionsCheckMarks[1].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[1];
                    ConditionsCheckMarks[2].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[2];
                    ConditionsCheckMarks[3].transform.GetChild(1).GetComponent<Text>().text = ActiveTask.TaskConditions[3];
                    break;
            }
            TaskName.text = ActiveTask.Taskname + ':';
        }
        else
        {
            foreach(Toggle checkMark in ConditionsCheckMarks)
            {
                checkMark.gameObject.SetActive(false);
            }
            TaskName.text = "Нет активных заданий";

        }
    }
}
