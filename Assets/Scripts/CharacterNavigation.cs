using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigation : NavigationController
{

	private int currentTargetIndex = 0;

	public List<Transform> targets;

	override protected void Start()
	{
        base.Start();
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
