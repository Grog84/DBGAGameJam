using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour {

	Animator m_Animator;
	public int animType;


	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator>();
		m_Animator.SetFloat("Selection", (float)animType);
	}
	
	
}
