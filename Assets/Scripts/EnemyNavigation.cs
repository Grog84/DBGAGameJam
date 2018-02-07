using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : NavigationController
{
	public Transform hero;

	protected override void Start()
	{
        base.Start();
        hero = FindObjectOfType<HeroManager>().transform;
		currentTarget = hero;
		agent.destination = currentTarget.position;
	}

	private void Update()
	{
		StartMovement(currentTarget);
	}
}
