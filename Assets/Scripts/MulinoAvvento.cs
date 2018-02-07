using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MulinoAvvento : MonoBehaviour {

    public void DestroyMulino()
    {
        ParticleManager.instance.EmitParticles(Effects.Smoke, transform.position);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            collision.gameObject.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
        }
    }
}
