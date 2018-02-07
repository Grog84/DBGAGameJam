using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoschiotteAnimation : MonoBehaviour {

    Animator m_Animator;
    NavMeshAgent m_Agent;

    Vector3 agentVelocity;
    Vector2 agentPlaneVelocity;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }


    private void UpdateAnimator()
    {
        agentVelocity =  m_Agent.velocity;
        agentPlaneVelocity = new Vector2(agentVelocity.x, agentVelocity.z);
        // float angle = 
    }


}
