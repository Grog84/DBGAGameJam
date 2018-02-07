﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoblinSwitch : MonoBehaviour {

    GameObject normalState;
    GameObject ragdollState;
    NavMeshAgent m_Agent;
    EnemyNavigation m_Navigation;

    public MouseDrag m_MouseDrag;

    bool isActive = true;

    private void Awake()
    {
        normalState = transform.FindDeepChild("Normal").gameObject;
        ragdollState = transform.FindDeepChild("Ragdoll").gameObject;
        m_Navigation = GetComponent<EnemyNavigation>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            SwitchStates();
            m_MouseDrag.OnMouseDown();

            //m_MouseDrag.LiftUp();
            //m_MouseDrag.isSelected = true;
        }

    }

    private void OnMouseUp()
    {
        m_MouseDrag.OnMouseUp();
    }

    public void SwitchStates()
    {
        normalState.SetActive(false);
        ragdollState.SetActive(true);
        m_Navigation.enabled = false;
        m_Agent.enabled = false;

        m_MouseDrag.thisObj = gameObject;

        isActive = false;
    }



}
