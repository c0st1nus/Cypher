using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cyph : MonoBehaviour
{
    public GameObject player;
    public TMP_Text text;
    public GameObject button;
    public string NPC_name = "����";
    private Cipher cipher = Cipher.NONE;
    private bool talking = false;
    private int replique = 0;
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
            "����: ��, ������ �� � ���� ����� ��� ������������, ������ ������� � ������� ������",
            "����: ��� ������ ��������� ��� �������������",
            "��: ����, ������� �������������?!",
            "����: ��, �� �� ����? ��� ����� �����������, ��� ��� ���� �� ��������� ������ ������, ��� � � �������",
            "����: � ��������� �� �� ����� �� �������� ����� ������ �����",
            "����: �� ���� �� ��������� ���� � ������� ���� �� ����� ������ ������ ��",
            "��: ������, ������� ����, ����� ��������, ��� ���"
    };
    public void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3.5f && !talking)
        {
            text.text = "Press E to talk";
            if (Input.GetKeyDown(KeyCode.E))
            {
                talking = true;
                StartCoroutine(HelloWordDialogue());
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
            stopTalking();
        }
    }

    public IEnumerator HelloWordDialogue()
    {
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
    }

    public void stopTalking()
    {
        StopAllCoroutines();
        text.text = null;
        talking = false;
        button.SetActive(false);
    }
}

