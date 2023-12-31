using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class CameraPlace : MonoBehaviour
{
    public GameObject placePoint;
    public GameObject[] places;
    public TMP_Text text;
    public GameObject player;
    private Animator animator;
    public GameObject vfx;
    public GameObject RealCamera;
    private bool isClose = false, placed = false;
    public GameObject PlaceForVFX;
    public CameraInTabletControl gamemanager;
    public TaskWindow GameManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!placed)
        {
            if (Vector3.Distance(player.transform.position, placePoint.transform.position) < 10f)
            {
                text.text = "press E to place a camera";
                isClose = true;
                foreach (GameObject obj in places)
                {
                    obj.GetComponent<MeshRenderer>().enabled = true;
                }
                animator.SetBool("ShouldAppear", true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(GameManager.ActiveTask != null)
                    {
                        GameManager.ActiveTask.TaskConditions[1] = "true";
                    }
                    StartCoroutine(vfxAppear());
                }
            }
            else if (Vector3.Distance(player.transform.position, placePoint.transform.position) > 10f && isClose)
            {
                if(text.text == "press E to place a camera")
                {
                    text.text = null;
                }
                isClose = false;
                animator.SetBool("ShouldAppear", false);
            }
        }
    }
    public void ShouldAppear()
    {
        if(!isClose) 
        {             
            foreach (GameObject obj in places)
            {
                obj.GetComponent<MeshRenderer>().enabled = false;
            }
            
        }
    }
    public IEnumerator vfxAppear ()
    {
        placed = true;
        foreach (GameObject obj in places)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }
        GameObject Vfx = Instantiate(vfx, PlaceForVFX.transform.position, PlaceForVFX.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        text.text = null;
        RealCamera.SetActive(true);
        gamemanager.camerasCount++;
    }
}
