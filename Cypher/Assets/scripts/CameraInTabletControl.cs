using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraInTabletControl : MonoBehaviour
{
    public int camerasCount;
    public RawImage[] placeForCameras;
    public Texture[] textures;
    public Texture interference;
    private void Update()
    {
        switch (camerasCount)
        {
            case 0:
                for(int i = 0; i<4; i++)
                {
                    placeForCameras[i].texture = interference;
                }
                break;
            case 1:
                placeForCameras[0].texture = textures[0];
                placeForCameras[1].texture = interference;
                placeForCameras[2].texture = interference;
                placeForCameras[3].texture = interference;
                break;
            case 2:
                placeForCameras[0].texture = textures[0];
                placeForCameras[1].texture = textures[1];
                placeForCameras[2].texture = interference;
                placeForCameras[3].texture = interference;
                break;
            case 3:
                placeForCameras[0].texture = textures[0];
                placeForCameras[1].texture = textures[1];
                placeForCameras[2].texture = textures[2];
                placeForCameras[3].texture = interference;
                break;
            case 4:
                placeForCameras[0].texture = textures[0];
                placeForCameras[1].texture = textures[1];
                placeForCameras[2].texture = textures[2];
                placeForCameras[3].texture = textures[3];
                break;
        }
    }
}
