using Fusion;
using UnityEngine;

public class FireMove : NetworkBehaviour
{
    public GameObject BulletPrefab;
    public Transform Fire;

    public NetworkRunner networkRunner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (networkRunner is not null && networkRunner.LocalPlayer.IsRealPlayer)
            {
               var bullet = networkRunner.Spawn(BulletPrefab, Fire.position, Fire.rotation);
                var bulletDirection = Fire.forward;
                bullet.GetComponent<Rigidbody>().AddForce(bulletDirection * 20f, ForceMode.Impulse);
            }
        }
    }

}
