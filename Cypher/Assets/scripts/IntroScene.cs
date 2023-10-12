using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroScene : MonoBehaviour
{
    public bool endOfGame = false;
    public MoveControl player;
    private string[] repliques = {
        "Добро пожаловать!",
        "Я - костя, еще недавно в юнити у меня ничего не получалось",
        "Но я решил не сдаваться и продолжать пытаться,",
        "И вот результат, я сделал свою первую игру!",
        "Все немного кривовато, может быть некрасиво, но я старался",
        "А еще мой кодекс был все сам",
        "Все в этой игре было сделанно мной, кроме моделек",
        "Модельки сделал мой друг Асхат, спасибо ему",
        "Если что, это демо версия игры"
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
        text.text = "Продолжение следует!";
        yield return new WaitForSeconds(3f);
        player.isActing = false;
        text.text = null;
        text.color = textColor;
        cube.SetActive(false);
    }
}
