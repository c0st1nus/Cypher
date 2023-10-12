using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cyph : MonoBehaviour
{
    private Task IntroTask = new Task("������ ���!", "���� ������, ��� ��� \"�������������\" ������ ��������� � ������� ��������, ����� ������ ����������", 1, "����", true);
    public GameObject player;
    public TMP_Text text;
    public GameObject button;
    public string NPC_name = "����";
    private Cipher cipher = Cipher.NONE;
    private bool talking = false;
    public GameObject gameManager;
    private Task afterDialogeTask;
    private string[] dialogue1 = {
            "����������: ��! �� �����, ��� ������? ������ ���� �� ��������",
            "��: �, � ��� ��������",
            "����������: �����, ������ �� �������",
            "��: ��, ������. � �� �� ������, ��� ��� �� ����� ����� � ��� ���� �����?",
            "����������: � - ����, � ��� �����, ��� �� ��������� ��� ���� ���������� �����",
            "��: ���? � �� �������, ��� �� ������ � ���� � ��� � ���� ��������",
            "����: �� �� � ����, ��� ��� �����, �� �������� ��� ����� �� ������",
            "����: �������� ��� ���-�� ��������� �����, �� �� �������� ��� � �� �������",
            "����: � ��� � ���� ��������, ������ ��� � �� ����� ������ ����������, �� ���� ��� ��� ��������",
            "��: ������ ��������, � ��� ����� �� ��� ����� ����������?",
            "����: � ��� ������ �� �����, �� �� ��������� ��� 30, ������ ���� ��� ��� 1, ���� ����� �����-��",
            "��: ��, �������, � �� �� ������, ��� ��� ������ ����� �������? ���� � ����� �� ������ ��� ��������",
            "����: ��, ������ �� � ���� ����� ��� ������������, ������ ������� � ������� ��������",
            "����: ��� ������ ��������� ��� �������������",
            "��: ����, ������� �������������?!",
            "����: ��, �� �� ����? ��� ����� �����������, ��� ��� ���� �� ��������� ������ ������, ��� � � �������",
            "����: � ��������� �� �� ����� �� �������� ����� ������ �����",
            "����: �� ���� �� ��������� ���� � ������� ���� �� ����� ������ ������ ��",
            "��: ������, ������� ����, ����� ��������, ��� ���",
            "����: �� �� ���, ���� ������, ������� ����� 12, ��� �����������"
    };
    private string answer = "�� ���� ������? � ���� ��� ��� ������";
    public bool isGone = false;

    private void Awake()
    {
        IntroTask.ConditionAdd("����� ������� ��������");
    }
    public void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3.5f && !talking)
        {
            text.text = "Press E to talk";
            if (Input.GetKeyDown(KeyCode.E))
            {
                talking = true;
                if (!isGone)
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (talking)
            {
                stopTalking();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            IntroTask.printTask();
        }
    }

    public IEnumerator HelloWordDialogue()
    {
        afterDialogeTask = IntroTask;
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
        isGone = true;
    }
    public IEnumerator AdditionalDialoge()
    {
        text.text = answer;
        yield return new WaitForSeconds(2f);
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
        isGone = true;
        gameManager.GetComponent<TaskWindow>().ActiveTask = afterDialogeTask;
    }
}
