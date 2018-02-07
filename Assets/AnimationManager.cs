using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;

    public void ChangeFloat()
    {
        anim.SetFloat("EnterExit", 1);
    }

    public void StopDeath()
    {
        Debug.Log("Entro");
        anim.SetInteger("DeathIndex", 0);
    }

}
