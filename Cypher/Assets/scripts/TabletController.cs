using UnityEngine;

public class TabletController : MonoBehaviour
{
    public GameObject mainCanvas, cameraCanvas, mainCamera;
    public GameObject[] tablet;
    public bool IsWatchingTablet;
    public KeyCode tabletOpen = KeyCode.Tab;
    private Animator animator;
    public MoveControl player;
    private float MaxAngle, MinAngle;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        MaxAngle = mainCamera.GetComponent<CameraControl>().maxAngle;
        MinAngle = mainCamera.GetComponent<CameraControl>().minAngle;
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!IsWatchingTablet)
            {
                mainCamera.GetComponent<CameraControl>().minAngle = -15f;
                mainCamera.GetComponent<CameraControl>().maxAngle = -5f;
                animator.SetBool("tablet", true);
                IsWatchingTablet = true;
                foreach(var i in tablet)
                {
                    i.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                animator.SetBool("tablet", false);
                IsWatchingTablet = false;
            }
        }
    }
    public void animEnd()
    {
        if (IsWatchingTablet)
        {
            mainCanvas.SetActive(false);
            cameraCanvas.SetActive(true);
            player.isActing = true;
        }
        else if(!IsWatchingTablet)
        { 
            mainCanvas.SetActive(true);
            cameraCanvas.SetActive(false);
            player.isActing = false;
        }
    }
    public void hideTablet()
    {
        mainCamera.GetComponent<CameraControl>().minAngle = MinAngle;
        mainCamera.GetComponent<CameraControl>().maxAngle = MaxAngle;
        foreach (var i in tablet)
        {
            i.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
