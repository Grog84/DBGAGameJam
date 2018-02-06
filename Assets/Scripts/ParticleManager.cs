using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        // Update is called once per frame
    }

    public void EmitParticles(ParticleSystem particle, Vector3 pos)
    {
        particle.transform.position = pos;
        particle.Emit(Random.Range(particle.GetComponent<EffectsParticle>().minParticles, particle.GetComponent<EffectsParticle>().maxParticles));
    }
}
