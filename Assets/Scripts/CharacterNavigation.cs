using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigation : NavigationController
{
<<<<<<< HEAD
	[HideInInspector]public NavMeshAgent agent;
	[HideInInspector]public Transform currentTarget;
	private int currentTargetIndex = 0;
	//private Transform lastTarget;
=======
	protected int currentTargetIndex = 0;
>>>>>>> c922b58457e6774dd41a93d4063898381177ac39
	public List<Transform> targets;

	private void Start()
	{
        agent = GetComponent<NavMeshAgent>();
		currentTarget = targets[currentTargetIndex];
		agent.destination = currentTarget.position;
	}

	private void Update()
	{
		StartMovement(currentTarget);

		if (currentTarget != null
				&& (new Vector2(currentTarget.transform.position.x, currentTarget.transform.position.z) - new Vector2(agent.transform.position.x, agent.transform.position.z)).sqrMagnitude
				<= agent.stoppingDistance)
		{
			OnTargetReached();
		}
	}

	private void OnTargetReached()
	{
		agent.isStopped = true;
		//lastTarget = currentTarget;
		if (agent.enabled && currentTargetIndex < targets.Count - 1)
		{
			ChangeNavPoint();
		}
		agent.isStopped = false;
	}

	void ChangeNavPoint()
	{
		currentTargetIndex++;
		currentTarget = targets[currentTargetIndex];
	}

}
