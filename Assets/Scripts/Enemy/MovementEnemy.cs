using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementEnemy : TransformUser
{
    private Transform _TargetEnd;

    public NavMeshAgent Agent { get; private set; }

    public void Initialized(Transform targetEnd)
    {
        Agent = GetComponent<NavMeshAgent>();
        _TargetEnd = targetEnd;
        Agent.destination = _TargetEnd.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform == _TargetEnd)
        {
            Destroy(gameObject);
        }
    }
}