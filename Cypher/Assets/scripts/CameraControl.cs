using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;
    private Vector3 cameraRotation, playerRotation;
    [SerializeField][Range(0.5f, 2f)] float sens = 1.35f;
    [SerializeField][Range(-85, 0f)] float minAngle = -45;
    [SerializeField][Range(0f, 85f)] float maxAngle = 45;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (!player.GetComponent<MoveControl>().isActing)
        {
            float MouseX = Input.GetAxis("Mouse X") * sens;
            float MoyseY = Input.GetAxis("Mouse Y") * sens;
            cameraRotation = transform.rotation.eulerAngles;
            playerRotation = player.rotation.eulerAngles;

            cameraRotation.x = (cameraRotation.x > 180) ? cameraRotation.x - 360 : cameraRotation.x;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, minAngle, maxAngle);
            cameraRotation.x -= MoyseY;

            cameraRotation.z = 0;
            playerRotation.y += MouseX;

            transform.rotation = Quaternion.Euler(cameraRotation);
            player.rotation = Quaternion.Euler(playerRotation);
        }
    }
}