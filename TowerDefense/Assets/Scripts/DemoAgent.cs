using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemoAgent : MonoBehaviour
{

    public Transform destination;

    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
    }
}
