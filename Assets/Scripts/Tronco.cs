using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour {

    public Transform targetDirection;
    Animator m_Animator;
    Rigidbody rb;
    public float speed;

    Vector3 rollingDirection;
    bool isRolling = false;

	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
        m_Animator.speed = 0;
        rb = GetComponent<Rigidbody>();
        rollingDirection = (targetDirection.position - transform.position).normalized;
    }

    public void StartRolling()
    {
        m_Animator.speed = 1f;
        isRolling = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
            m_Animator.SetTrigger("Explosion");
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            ParticleManager.instance.EmitParticles(Effects.Death, collision.transform.position);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Interactable")
        {
            collision.gameObject.GetComponent<MouseDrag>().anim.SetTrigger("Explosion");
        }
        else if (collision.gameObject.tag == "Wall")
        {
            DestroyTronco();
        }

    }

    public void DestroyTronco()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(isRolling)
            rb.velocity = rollingDirection * speed;
    }

}
