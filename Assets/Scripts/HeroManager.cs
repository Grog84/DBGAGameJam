﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum DeathType { None = 0, Decapitation = 1, Squished = 2 }

public class HeroManager : MonoBehaviour
{
    public GameObject heroHead;
    public Animator anim;
    public float headForce;

    public bool startStun = false;
    public bool endStun = true;

    public bool startScared = false;
    public bool endScared = true;

    public bool startDrunk = false;
    public bool endDrunk = true;

    public bool startCharmed = false;
    public bool endCharmed = true;

    [Header("Statistics and Cooldowns")]
    public float enterStunDuration;
    public float stunDuration;

    public float enterScaredDuration;
    public float scaredDuration;

    public float enterDrunkDuration;
    public float drunkDuration;

    public float charmedDuration;
    NavMeshAgent m_NavAgent;


    private void Awake()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
    }

    public void Death(DeathType death, Transform enemy)
    {
        anim.SetInteger("DeathIndex", (int)death);
        m_NavAgent.speed = 0;

        if (death == DeathType.Decapitation)
        {
            Vector3 dir = (enemy.position - transform.position).normalized;
            heroHead.SetActive(true);
            heroHead.transform.parent = null;
            heroHead.GetComponent<Rigidbody>().AddForce(dir * headForce);
        }
    }

    IEnumerator Stun()
    {
        startStun = false;
        endStun = false;
        anim.SetFloat("State", 1);
        yield return new WaitForSeconds(stunDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        endStun = true;
    }

    IEnumerator Scared()
    {
        startScared = false;
        endScared = false;
        anim.SetFloat("State", 2);
        yield return new WaitForSeconds(scaredDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        endScared = true;
    }

    IEnumerator Drunk()
    {
        startDrunk = false;
        endDrunk = false;
        anim.SetFloat("State", 3);
        yield return new WaitForSeconds(drunkDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        endDrunk = true;
    }

    IEnumerator Charmed()
    {
        startCharmed = false;
        endCharmed = false;
        anim.SetFloat("State", 4);
        yield return new WaitForSeconds(charmedDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        endCharmed = true;
    }

  

    void Update ()
    {
		if(startStun)
        {
            StartCoroutine(Stun());
        }
        if (startScared)
        {
            StartCoroutine(Scared());
        }
        if (startDrunk)
        {
            StartCoroutine(Drunk());
        }
        if (startCharmed)
        {
            StartCoroutine(Charmed());
        }
    }
}
