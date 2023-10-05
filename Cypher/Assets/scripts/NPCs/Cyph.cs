using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cyph : MonoBehaviour
{
    public GameObject player;
    public TMP_Text text;
    public GameObject button;
    public string NPC_name = "Суйф";
    private Cipher cipher = Cipher.NONE;
    private bool talking = false;
    private int replique = 0;
    private string[] dialogue1 = {
            "Незнакомец: Эй! Эй слага, кем будешь? Раньше тебя не встречал",
            "Ты: Я, я тут очудился",
            "Незнакомец: Понял, видимо ты новичек",
            "Ты: Да, видимо. А ты не знаешь, что это за место такое и как тебя зовут?",
            "Незнакомец: Я - суйф, а это место, где ты проведешь всю свою оставшуюся жизнь",
            "Ты: Что? Я не понимаю, что ты имеешь в виду и имя у тебя странное",
            "Суйф: Ну то и имею, что это место, из которого еще никто не уходил",
            "Суйф: Возможно это что-то наподобие тюрмы, но по условиям так и не скажешь",
            "Суйф: А имя у меня странное, потому что я не помню своего настоящего, но меня тут так прозвали",
            "Ты: Хорошо допустим, а как долго ты уже здесь находишься?",
            "Суйф: Я уже сбился со счету, но по ощущениям лет 30, каждый день уже как 1, день сурка какой-то",
            "Ты: Хм, понятно, а ты не знаешь, что мне сейчас нужно сделать? Ведь я здесь не просто так очутился",
            "Суйф: Ну, вообще ни у кого здесь нет обязательств, можешь сходить в комнату отдыха",
            "Суйф: Там обычно находятся все зашифрованные",
            "Ты: Стой, всмысле зашифрованные?!",
            "Суйф: Да, ты не знал? Все здесь зашифрованы, это мне шифр не присвоили видимо забыли, оно и к лучшему",
            "Суйф: А остальные же ни слова не понимают кроме своего шифра",
            "Суйф: но если ты занимался этим в прошлом тебе не будет сложно понять их",
            "Ты: Хорошо, спасибо тебе, пойду посмотрю, что там"
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

