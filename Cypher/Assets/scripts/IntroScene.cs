using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroScene : MonoBehaviour
{
    public bool endOfGame = false;
    public MoveControl player;
    private string[] repliques = {
        "����� ����������!",
        "� - �����, ��� ������� � ����� � ���� ������ �� ����������",
        "�� � ����� �� ��������� � ���������� ��������,",
        "� ��� ���������, � ������ ���� ������ ����!",
        "��� ������� ���������, ����� ���� ���������, �� � ��������",
        "� ��� ��� ������ ��� ��� ���",
        "��� � ���� ���� ���� �������� ����, ����� �������",
        "�������� ������ ��� ���� �����, ������� ���",
        "���� ���, ��� ���� ������ ����"
    };
    [SerializeField] private GameObject cube;
    public TMP_Text text;
    public void Start()
    {
        StartCoroutine(HelloWordDialogue());
    }
    private IEnumerator HelloWordDialogue()
    {
        cube.SetActive(true);
        player.isActing = true;
        Color textColor = text.color;
        text.color = Color.white;
        yield return new WaitForSeconds(3f);
        text.text = null;
        for (int i = 0; i < repliques.Length; i++)
        {
            text.text = repliques[i];
            yield return new WaitForSeconds(2f);
        }
        player.isActing = false;
        text.text = null;
        text.color = textColor;
        cube.SetActive(false);
    }
    private IEnumerator GoodBuy()
    {
        cube.SetActive(true);
        player.isActing = true;
        Color textColor = text.color;
        text.color = Color.white;
        text.text = "����������� �������!";
        yield return new WaitForSeconds(3f);
        player.isActing = false;
        text.text = null;
        text.color = textColor;
        cube.SetActive(false);
    }
}
