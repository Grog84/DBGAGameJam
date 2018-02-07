using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DirectionAnimation : MonoBehaviour {

    public Animator m_Animator;
    NavMeshAgent m_Agent;

    Vector3 agentVelocity;
    Vector2 agentPlaneVelocity;
    float directionAngle;

    [Range(5, 80)]
    public float sideAngleRange = 20f; 

    public virtual void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }


    private void UpdateAnimator()
    {
        agentVelocity =  m_Agent.velocity;
        agentPlaneVelocity = new Vector2(agentVelocity.x, agentVelocity.z);

        if (agentPlaneVelocity.x > 0 && agentPlaneVelocity.y > 0)
            directionAngle = Mathf.Rad2Deg * Mathf.Atan(agentPlaneVelocity.y / agentPlaneVelocity.x);
        else if (agentPlaneVelocity.x < 0 && agentPlaneVelocity.y > 0)
            directionAngle = 90f + Mathf.Rad2Deg * Mathf.Atan(agentPlaneVelocity.x / -agentPlaneVelocity.y);
        else if (agentPlaneVelocity.x < 0 && agentPlaneVelocity.y < 0)
            directionAngle = 180f + Mathf.Rad2Deg * Mathf.Atan(-agentPlaneVelocity.x / -agentPlaneVelocity.y);
        else if (agentPlaneVelocity.x > 0 && agentPlaneVelocity.y < 0)
            directionAngle = 270f + Mathf.Rad2Deg * Mathf.Atan(agentPlaneVelocity.x / -agentPlaneVelocity.y);
        else if (agentPlaneVelocity.x == 0 && agentPlaneVelocity.y > 0)
            directionAngle = 90f;
        else if (agentPlaneVelocity.x == 0 && agentPlaneVelocity.y < 0)
            directionAngle = 270f;
        else if (agentPlaneVelocity.x > 0 && agentPlaneVelocity.y == 0)
            directionAngle = 0f;
        else if (agentPlaneVelocity.x < 0 && agentPlaneVelocity.y == 0)
            directionAngle = 180f;

        // Debug.Log(directionAngle);

        if (directionAngle < sideAngleRange || directionAngle > (360f - sideAngleRange))
        {
            m_Animator.SetFloat("Direction", 1f);
        }
        else if (directionAngle > sideAngleRange && directionAngle < (180f - sideAngleRange))
        {
            m_Animator.SetFloat("Direction", 0f);
        }
        else if (directionAngle > (180f - sideAngleRange) && directionAngle < (270f - sideAngleRange))
        {
            m_Animator.SetFloat("Direction", 3f);
        }
        else if (directionAngle > (270f - sideAngleRange) && directionAngle < (360f - sideAngleRange))
        {
            m_Animator.SetFloat("Direction", 2f);
        }
    }

    private void Update()
    {
        UpdateAnimator();
    }

}
