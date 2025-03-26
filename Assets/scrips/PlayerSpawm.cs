using Fusion;
using UnityEngine;

public class PlayerSpawm : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            var position = new Vector3(0 , 2, 0);
            Runner.Spawn
                (
                PlayerPrefab,
                position,
                Quaternion.identity,
                Runner.LocalPlayer,
                (runner,obj) =>
                    {
                         var playerSetup = obj.GetComponent<PlayerSetup>();
                         if (playerSetup != null)
                         {
                             playerSetup.SetUpCamera();
                         }
                         var fireMove = obj.GetComponent<FireMove>();
                        if (fireMove != null) fireMove.networkRunner = runner;

                        var hpmp = obj.GetComponent<HPMP>();
                        if (hpmp != null)
                        {
                            hpmp.networkRunner = runner;
                            hpmp.networkObject = obj;
                        }
                    }
                );

           //Runner.Spawn(PlayerPrefab, new Vector3 (0, 1, 0), Quaternion.identity);
        }
    }
}
