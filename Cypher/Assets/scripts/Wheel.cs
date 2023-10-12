using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public GameObject LitleWheel;
    private float rotationAngle = 0f;
    public float change;
    public int step = 0;
    public bool isPlaying = false;
    public int targetStep = 0;
    public TMPro.TMP_Text text;
    private int[] chars = {1055, 1088, 1080, 1074, 1077, 1090};
    private int previousStep;
    public GameObject game;
    public MoveControl player;
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rotationAngle += change;
                step += 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rotationAngle -= change;
                step -= 1;
            }
            if (step >= 32)
            {
                step = 0;
            }
            if (step <= -1)
            {
                step = 31;
            }
            Quaternion rotation = Quaternion.Euler(rotationAngle, -3.035f, -90f).normalized;
            LitleWheel.transform.rotation = Quaternion.Lerp(LitleWheel.transform.rotation, rotation, 0.25f);
            if(previousStep != step)
            {
                text.text = "ûüôíğş";
            }
            if (targetStep == step)
            {
                text.text = "ïğèâåò";
                StartCoroutine(wait());
                
            }
            previousStep = step;
            Debug.Log(step);
        }
    }
    IEnumerator wait()
    {
        isPlaying = false;
        yield return new WaitForSeconds(2f);
        game.SetActive(false);
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.isActing = false;
        text.text = null;
        text.color = Color.black;
    }
    public void startGame(int targetStep, ref bool isCyphed)
    {
        text.color = Color.white;
        player.transform.GetChild(0).gameObject.SetActive(false);
        game.SetActive(true);
        player.isActing = true;
        this.targetStep = targetStep;
        for (int i = 0; i<chars.Length; i++)
        {
            chars[i] = chars[i] + targetStep;
        }
        isPlaying = true;
        isCyphed = false;
    }
}
