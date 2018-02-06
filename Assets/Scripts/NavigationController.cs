using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform currentTarget;
    //private Transform lastTarget;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void StartMovement(Transform target)
	{
		if (target != null)
		{
			agent.isStopped = false;
			agent.destination = currentTarget.position;
		}
	}

	public void StopMovement()
	{
		agent.isStopped = true;
	}
}
