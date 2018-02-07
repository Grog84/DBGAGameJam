using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathType { None = 0, Decapitation = 1, Squished = 2 }

public class HeroManager : MonoBehaviour
{
    public GameObject heroHead;
    public Animator anim;
    public float headForce;

	void Start () {
		
	}
	
    public void Death(DeathType death, Transform enemy)
    {
        Vector3 dir = (enemy.position - transform.position).normalized;
        anim.SetInteger("DeathIndex", (int)death);
        heroHead.SetActive(true);
        heroHead.GetComponent<Rigidbody>().AddForce(dir * headForce); 
    }

	void Update () {
		
	}
}
