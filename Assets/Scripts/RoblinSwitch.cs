using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoblinSwitch : MonoBehaviour {

    GameObject normalState;
    GameObject ragdollState;
    NavMeshAgent m_Agent;
    EnemyNavigation m_Navigation;

    public Animator anim;
    public MouseDrag m_MouseDrag;

    bool isActive = true;

    public AudioSource roblinSound;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(normalState.activeSelf)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
            {
                anim.SetFloat("State",2);
                collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
            }
        }
    }

    private void OnMouseUp()
    {
        m_MouseDrag.OnMouseUp();
    }

    public void SwitchStates()
    {
        roblinSound.Play();
        normalState.SetActive(false);
        ragdollState.SetActive(true);
        m_Navigation.enabled = false;
        m_Agent.enabled = false;

        m_MouseDrag.thisObj = gameObject;

        isActive = false;

    }



}
