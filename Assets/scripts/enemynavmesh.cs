using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemynavmesh : MonoBehaviour
{
    [SerializeField]
    private Transform movePosionTransform;

    private NavMeshAgent NavMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.stoppingDistance = 1;
    }

    // Update is called once per frame
    void Update()
    {
            NavMeshAgent.destination = movePosionTransform.position;
    }
}
