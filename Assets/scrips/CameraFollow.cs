using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineCamera Followcamera;

    public void AssingCamera(Transform targets)
    {
        Followcamera.Follow = targets;  
        Followcamera.LookAt = targets;
    }
}
