using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nill : MonoBehaviour
{
    public Task CameraTask = new Task("Зашифрованный", "Этот парень, что то сказал, но я ничего не понял, может быть шифр", 1, "Нил", true);
    public GameObject player;
    public TMP_Text text;
    public GameObject button;
    public string NPC_name = "Суйф";
    private Cipher cipher = Cipher.NONE;
    private bool talking = false;
    public GameObject gameManager;
    private Task afterDialogeTask;
    public bool isCyphed = true;
    private string[] dialogue1 = {
            "Незнакомец: Привет! А ты кто, не видел тебя здесь раньше",
            "Ты: Конечно не видел, я ведь новенький, а как тебя можно называть?",
            "Незнакомец: Неужели! Не ожидал уведь сегодня новенького, я Нил",
            "Ты: Приятно познакомиться, я... а я не знаю как меня зовут",
            "Нил: Не знаешь как тебя зовут? Это странно, но ничего, я помогу тебе,",
            "Нил: тем более тебе следует знать одну вещь об этом месте",
            "Ты: Спасибо, может начнем?",
            "Нил: Хорошо, в этом месте есть много людей, которые могут тебе помочь, но есть и те,",
            "Нил: которые могут тебе навредить, поэтому тебе сначала нужно узнать их мотивы",
            "Нил: хоть мы и в тюрьме мы пользуемся технологиями, например тебе может помочь камера",
            "Нил: она позволяет проследить за человеком, но для начале ее желательно установить",
            "Нил: в комнате обывания, сзади от тебя можно поставить одну такую",
            "Ты: Сейчас попробую!"
    };
    private string answer = "Незнакомец: Ыьфнрю, л юж цюъ?";

    private void Awake()
    {
        CameraTask.ConditionAdd("Поставить камеру");
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
        text.text = "Вы: Точно! Суйф ведь говорил что здесь все зашифрованны";
        yield return new WaitForSeconds(2f);
        text.text = "Вы: Похоже на шифр цезаря, следует попробовать";
        yield return new WaitForSeconds(2f);
        text.text = "\" Нажми на P, чтобы расшифровать персонажа \"";
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
