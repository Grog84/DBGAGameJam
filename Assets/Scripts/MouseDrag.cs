using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public float liftUpAmount = 5;
    public bool isSelected = false;
    public float multiplyFactor = 1f;
    public float scaleAmount = 1.5f;
    public float yForceAmount = 2f;
    public float maxSqrMagnitude = 1;
    public bool isThrown = false;
    public bool isLanding = false;
    public Effects impactParticle;
    public Effects deathParticle;
    public LayerMask groundMask;

    public Animator anim;
    Rigidbody m_Brigidbody;
    public Transform m_Sprite;
    public GameObject thisObj;

    //private void OnMouseDrag()
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    transform.position = objPosition;
    //}

    private void Awake()
    {
        m_Brigidbody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        thisObj = gameObject;
    }

    public void OnMouseDown()
    {
        // select
        // sollevamento personaggio
        if (!isSelected)
        {
            LiftUp();
            isSelected = true;
        }

    }

    public void OnMouseUp()
    {
        // release    
        if (!isThrown)
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        isLanding = true;
        isThrown = true;
        m_Brigidbody.isKinematic = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, groundMask))
        {
            Vector3 dir = hit.point - transform.position;
            float mag = dir.sqrMagnitude;
            mag = Mathf.Min(mag, maxSqrMagnitude);
            Debug.Log((float)mag);
            dir = dir.normalized * mag;
            dir.y = yForceAmount;
            m_Brigidbody.AddForce(dir * multiplyFactor);
        }
    }

    public void LiftUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + liftUpAmount, transform.position.z );
        m_Brigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground" || collision.gameObject.layer == LayerMask.NameToLayer("Enemy")|| collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            isSelected = false;
            isThrown = false;
            m_Sprite.localScale = new Vector3(1 , 1 , 1);

            if (isLanding)
            {
                isLanding = false;

                if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    ParticleManager.instance.EmitParticles(impactParticle, transform.position);
                    if(collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
                    {
                        collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Squished,transform);
                    }

                    Destroy(thisObj);
                }

                if(gameObject.tag == "Interactable")
                {
                    if (collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
                    {
                        collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Squished, transform);

                    } 
                    anim.SetTrigger("Explosion");

                }
            }
            else
            {
                if (gameObject.tag == "Interactable")
                {
                    if (collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
                    {
                        Debug.Log("Entro");
                        anim.SetTrigger("Explosion");
                        collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
                    }

                }
            }
        }
    }


    private void Update()
    {
        if (isSelected)
        {
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(transform.position, Vector3.down, out hit, groundMask);
            m_Sprite.localScale = new Vector3(1 + (scaleAmount * hit.distance), 1 + (scaleAmount * hit.distance), 1 );
        }
    }

}
