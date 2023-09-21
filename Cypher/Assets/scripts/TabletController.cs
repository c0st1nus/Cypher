
using UnityEditor.VersionControl;
using UnityEngine;

public class TabletController : MonoBehaviour
{
    public GameObject mainCanvas, cameraCanvas, tablet;
    public bool IsWatchingTablet;
    public KeyCode tabletOpen = KeyCode.Tab;
    private Animator animator;
    public MoveControl player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab");
            if (!IsWatchingTablet)
            {
                animator.SetBool("tablet", true);
                IsWatchingTablet = true;
                tablet.GetComponent<MeshRenderer>().enabled = true;
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
            Debug.Log("niiga");
            mainCanvas.SetActive(false);
            cameraCanvas.SetActive(true);
            player.isActing = true;
        }
        else if(!IsWatchingTablet)
        {
            Debug.Log("sega0");
            mainCanvas.SetActive(true);
            cameraCanvas.SetActive(false);
            player.isActing = false;
        }
    }
}
