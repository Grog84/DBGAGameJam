using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    float initialSpeed;

    [Header("Statistics and Cooldowns")]
    public float stunDuration;

    public float scaredDuration;

    public float drunkDuration;

    NavMeshAgent m_NavAgent;
    [Space(10)]
    public AudioEmitter deathAudio;
    public AudioEmitter winAudio;

    private void Awake()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
        float initialSpeed = m_NavAgent.speed;
    }

    public void Death(DeathType death, Transform enemy)
    {
        anim.SetInteger("DeathIndex", (int)death);
        m_NavAgent.speed = 0;
        deathAudio.PlaySound();

        if (death == DeathType.Decapitation)
        {
            Vector3 dir = (enemy.position - transform.position).normalized;
            heroHead.SetActive(true);
            heroHead.transform.parent = null;
            heroHead.GetComponent<Rigidbody>().AddForce(dir * headForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FearTrigger")
        {
            other.GetComponent<FearTrigger>().m_Tronco.StartRolling();
            startScared = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Beer")
        {
            startDrunk = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Stun()
    {
        startStun = false;
        endStun = false;
        anim.SetFloat("State", 1);
        yield return new WaitForSeconds(0.3f);
        anim.SetFloat("EnterExit", 1);
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
        yield return new WaitForSeconds(0.3f);
        anim.SetFloat("EnterExit", 1);
        yield return new WaitForSeconds(scaredDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        endScared = true;
    }

    IEnumerator Drunk()
    {
        m_NavAgent.speed = 0;
        startDrunk = false;
        endDrunk = false;
        anim.SetFloat("State", 3);
        yield return new WaitForSeconds(0.3f);
        anim.SetFloat("EnterExit", 1);
        yield return new WaitForSeconds(drunkDuration);
        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        m_NavAgent.speed = initialSpeed;
        endDrunk = true;
    }

    IEnumerator Charmed()
    {
        startCharmed = false;
        endCharmed = false;
        anim.SetFloat("State", 4);
        while (!endCharmed)
        {
            yield return null;
        }

        anim.SetFloat("EnterExit", 0);
        anim.SetFloat("State", 0);
        
    }

    IEnumerator RestartLev()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
