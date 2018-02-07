using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;

    public void ChangeFloat()
    {
        Debug.Log("Entro");
        anim.SetFloat("EnterExit", 1);
    }

    public void StopDeath()
    {
        anim.SetInteger("DeathIndex", 0);
    }

}
