using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathParticleSettings : EffectsParticle
{
    public ParticleSystem particle;
    int min;
    int max;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
      
    }

    public override void EmitParticles()
    {
        particle = GetComponent<ParticleSystem>();
        var emission = particle.emission;
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[emission.burstCount];
        emission.GetBursts(bursts);
        max = bursts[0].maxCount;
        min = bursts[0].minCount;
        particle.Emit(Random.Range(min, max));
    }
}
