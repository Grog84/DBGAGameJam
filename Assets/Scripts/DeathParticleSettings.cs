using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathParticleSettings : EffectsParticle
{
    public ParticleSystem particle;
    public ParticleSystem[] particleChilds;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
      
    }
}
