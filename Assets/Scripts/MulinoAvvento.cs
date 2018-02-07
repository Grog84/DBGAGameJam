using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MulinoAvvento : MonoBehaviour {

    public void DestroyMulino()
    {
        Debug.Log("DestroyMulino");
     
        ParticleManager.instance.EmitParticles(Effects.Smoke, transform.position);
        Destroy(gameObject);
    }
}
