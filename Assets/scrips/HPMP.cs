using Fusion;
using TMPro;
using UnityEngine;

public class HPMP : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(OnhealthChanged))]
    public float HP { get; set; }
    public float maxHP { get; set; }

    public TextMeshProUGUI HpText;

    public NetworkObject networkObject;
    public NetworkRunner networkRunner;

    public void Start()
    {
        maxHP = 100;
        HP = maxHP;
        HpText.text = $"{HP}/{maxHP}";
    }
    public void OnhealthChanged()
    {
        HpText.text = $"{HP}/{maxHP}";
    }


    [Networked, OnChangedRender(nameof(OnSpeedChange))]
    public float Speed { get; set; }
    public Animator animator;
    public int speedHasd = Animator.StringToHash("Speed");

    public void OnSpeedChange()
    {
        animator.SetFloat(speedHasd, Speed);
    }

    //[Networked, OnChangedRender(nameof(OnPlayerInfoChanged))]
    //public PlayerNEtwordInfo playerInfo { get; set; }

    //public void OnPlayerInfoChanged()
    //{

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HP -= 10;
        }
        if (HP <= 0)
        {
            //chet
            //khong su dung Destroy
            networkRunner.Despawn(networkObject);

        }
    }
}
