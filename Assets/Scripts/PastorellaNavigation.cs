using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastorellaNavigation : NavigationController
{
    Pastorella m_Pastorella;
    private int currentTargetIndex = 0;

    public List<Transform> targets;

    override protected void Start()
    {
        base.Start();
        currentTarget = targets[currentTargetIndex];
        agent.destination = currentTarget.position;
        m_Pastorella = GetComponent<Pastorella>();
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
        else
        {
            m_Pastorella.Disappear();
        }
        agent.isStopped = false;
    }

    void ChangeNavPoint()
    {
        currentTargetIndex++;
        currentTarget = targets[currentTargetIndex];
    }
}
