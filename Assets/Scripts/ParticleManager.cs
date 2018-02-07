using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effects { Death = 0, Smoke = 1}

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance = null;
    public ParticleSystem[] particles;
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

    public void EmitParticles(Effects effect, Vector3 pos)
    {
        particles[(int)effect].transform.position = pos;
        particles[(int)effect].GetComponent<EffectsParticle>().EmitParticles();
    }

}
