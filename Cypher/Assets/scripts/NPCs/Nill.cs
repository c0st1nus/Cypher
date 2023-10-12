using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nill : MonoBehaviour
{
    public Task CameraTask = new Task("�������������", "���� ������, ��� �� ������, �� � ������ �� �����, ����� ���� ����", 1, "���", true);
    public GameObject player;
    public TMP_Text text;
    public GameObject button;
    public string NPC_name = "����";
    private Cipher cipher = Cipher.NONE;
    private bool talking = false;
    public GameObject gameManager;
    private Task afterDialogeTask;
    public bool isCyphed = true;
    private string[] dialogue1 = {
            "����������: ������! � �� ���, �� ����� ���� ����� ������",
            "��: ������� �� �����, � ���� ���������, � ��� ���� ����� ��������?",
            "����������: �������! �� ������ ����� ������� ����������, � ���",
            "��: ������� �������������, �... � � �� ���� ��� ���� �����",
            "���: �� ������ ��� ���� �����? ��� �������, �� ������, � ������ ����,",
            "���: ��� ����� ���� ������� ����� ���� ���� �� ���� �����",
            "��: �������, ����� ������?",
            "���: ������, � ���� ����� ���� ����� �����, ������� ����� ���� ������, �� ���� � ��,",
            "���: ������� ����� ���� ���������, ������� ���� ������� ����� ������ �� ������",
            "���: ���� �� � � ������ �� ���������� ������������, �������� ���� ����� ������ ������",
            "���: ��� ��������� ���������� �� ���������, �� ��� ������ �� ���������� ����������",
            "���: � ������� ��������, ����� �� ���� ����� ��������� ���� �����",
            "��: ������ ��������!"
    };
    private string answer = "����������: ������, � �� ���?";

    private void Awake()
    {
        CameraTask.ConditionAdd("��������� ������");
    }
    public void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 5f && !talking)
        {
            text.text = "Press E to talk";
            if (Input.GetKeyDown(KeyCode.E))
            {
                talking = true;
                if (!isCyphed)
                {
                    StartCoroutine(HelloWordDialogue());
                }
                else
                {
                    StartCoroutine(AdditionalDialoge());
                }
                button.SetActive(true);
            }
        }
        else
        {
            if(text.text == "Press E to talk")
            {
                text.text = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.GetComponent<Wheel>().startGame(12, ref isCyphed);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (talking)
            {
                stopTalking();
            }
        }
    }

    public IEnumerator HelloWordDialogue()
    {
        afterDialogeTask = CameraTask;
        text.text = null;
        for (int i = 0; i < dialogue1.Length; i++)
        {
            bool skip = false;
            text.text = dialogue1[i];
            if(Input.GetMouseButton(0))
            {
                skip = true;
            }
            yield return new WaitForSeconds(0.5f);
            if (skip)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
        }
        text.text = null;
        talking = false;
        button.SetActive(false);
        gameManager.GetComponent<TaskWindow>().ActiveTask = afterDialogeTask;
    }
    public IEnumerator AdditionalDialoge()
    {
        text.text = answer;
        yield return new WaitForSeconds(2f);
        text.text = "��: �����! ���� ���� ������� ��� ����� ��� ������������";
        yield return new WaitForSeconds(2f);
        text.text = "��: ������ �� ���� ������, ������� �����������";
        yield return new WaitForSeconds(2f);
        text.text = "\" ����� �� P, ����� ������������ ��������� \"";
        yield return new WaitForSeconds(1f);
        text.text = null;
        talking = false;
        button.SetActive(false);
    }

    public void stopTalking()
    {
        StopAllCoroutines();
        text.text = null;
        talking = false;
        button.SetActive(false);
        gameManager.GetComponent<TaskWindow>().ActiveTask = afterDialogeTask;
    }
}
