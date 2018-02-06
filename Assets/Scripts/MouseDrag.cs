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

    public LayerMask groundMask;

    Rigidbody m_Rigidbody;
    public Transform m_Sprite;

    //private void OnMouseDrag()
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    transform.position = objPosition;
    //}

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        // select
        // sollevamento personaggio
        LiftUp();
        isSelected = true;

    }

    private void OnMouseUp()
    {
        // release    

        ThrowObject();
    }

    void ThrowObject()
    {
        m_Rigidbody.isKinematic = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 dir = hit.point - transform.position;
            dir.y = yForceAmount;
            
            Debug.Log(dir);

            m_Rigidbody.AddForce(dir * multiplyFactor);
        }
    }

    void LiftUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + liftUpAmount, transform.position.z );
        m_Rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isSelected = false;
            m_Sprite.localScale = new Vector3(1 , 1 , 1);
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
