using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioEmitter explosionAudio;

    public void DestroyBomb()
    {
        transform.parent.GetComponent<Bomb>().numberOfTap = -1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("DestroyHero");
            other.GetComponent<HeroManager>().Death(DeathType.Decapitation, transform);
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("DestroyEnemy");
            ParticleManager.instance.EmitParticles(Effects.Death, other.transform.position);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Mulino")
        {
            Debug.Log("DestroyMulino");
            other.GetComponent<MulinoAvvento>().DestroyMulino();
        }
        else if (other.tag == "Interactable")
        {
            Debug.Log("DestroyInter");
            other.GetComponent<MouseDrag>().anim.SetTrigger("Explosion");
        }
        

    }

    private void Start()
    {
        explosionAudio = GetComponent<AudioEmitter>();
        explosionAudio.PlaySound();
    }

}
