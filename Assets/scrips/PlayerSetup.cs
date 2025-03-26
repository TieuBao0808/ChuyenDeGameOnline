using Fusion;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    //set up camera cho nguoi choi
    public void SetUpCamera()
    {
        if (Object.HasStateAuthority)
        {
            var CameraFollow = FindAnyObjectByType<CameraFollow>();   
            if (CameraFollow != null)
            {
                CameraFollow.AssingCamera(transform);
            }
        }
    }
    // set up .....

}
