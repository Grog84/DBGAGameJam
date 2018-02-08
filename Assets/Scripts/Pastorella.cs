using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastorella : MonoBehaviour {

    HeroManager heroManager;
    public AudioEmitter spawn;

    private void Start()
    {
        heroManager = FindObjectOfType<HeroManager>();
        CharmPlayer();
        spawn.PlaySound();
    }

    void CharmPlayer()
    {
        heroManager.startCharmed = true;
    }

    void EndCharmPlayer()
    {
        heroManager.endCharmed = true;
    }

    public void Disappear()
    {
        EndCharmPlayer();
        Destroy(gameObject);
    }

}
