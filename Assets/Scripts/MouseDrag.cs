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
    public GameObject blood;

    public LayerMask groundMask;

    Rigidbody m_Brigidbody;
    public Transform m_Sprite;

    //private void OnMouseDrag()
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    transform.position = objPosition;
    //}

    private void Awake()
    {
        m_Brigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        // select
        // sollevamento personaggio
        if (!isSelected)
        {
            LiftUp();
            isSelected = true;
        }

    }

    private void OnMouseUp()
    {
        // release    
        if (!isThrown)
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        isThrown = true;
        m_Brigidbody.isKinematic = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 dir = hit.point - transform.position;
            dir.y = yForceAmount;
            float mag = dir.sqrMagnitude;
            mag = Mathf.Min(mag, maxSqrMagnitude);

            m_Brigidbody.AddForce(dir.normalized * mag * multiplyFactor);
        }
    }

    void LiftUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + liftUpAmount, transform.position.z );
        m_Brigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Enemy")
        {
            isSelected = false;
            isThrown = false;
            m_Sprite.localScale = new Vector3(1 , 1 , 1);
            ParticleManager.instance.EmitParticles(blood,transform.position);
        }
        //if(isSelected && collision.transform.tag == "Enemy")
        //{

        //}
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
