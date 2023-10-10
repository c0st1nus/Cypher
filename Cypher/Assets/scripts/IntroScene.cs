using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroScene : MonoBehaviour
{
    public MoveControl player;
    private string[] repliques = {
        "Ну привет дорогой игрок",
        "Я твой гид по этой игре",
        "Давай я тебе расскажу что тут происходит",
        "Ты находишься в мире, где все существа состоят из кубиков",
        "Ты тоже состоишь из кубиков",
        "Ты можешь управлять своим кубиком с помощью стрелок",
        "Ты можешь прыгать с помощью пробела",
    };
    [SerializeField] private GameObject cube;
    public TMP_Text text;
    public void Start()
    {
        StartCoroutine(HelloWordDialogue());
    }
    private IEnumerator HelloWordDialogue()
    {
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
}
