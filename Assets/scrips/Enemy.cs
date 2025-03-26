using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] Targets;
    void Update()
    {
        // tim gameobject co Tag Player
        Targets = GameObject.FindGameObjectsWithTag("Player");
        if(Targets.Length == 0) return;

        //tim targets gan nhat
        GameObject targets = null;
        float minDistance = Mathf.Infinity;
        foreach (var t in Targets)
        {
            var distance = Vector3.Distance(t.transform.position, transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                targets = t;
            }
        }
        if (targets != null)
        {
            agent.SetDestination(targets.transform.position);
        }

    }
}
