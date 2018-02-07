using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public void DestroyBomb()
    {
        transform.parent.GetComponent<Bomb>().numberOfTap = -1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            other.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
        }
        else if (other.tag == "Enemy")
        {
            ParticleManager.instance.EmitParticles(Effects.Death, other.transform.position);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Mulino")
        {
            other.GetComponent<MulinoAvvento>().DestroyMulino();
        }
        else if (other.tag == "Interactable")
        {
            other.GetComponent<MouseDrag>().anim.SetTrigger("Explosion");
        }
        

    }

}
