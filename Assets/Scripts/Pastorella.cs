using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastorella : MonoBehaviour {

    HeroManager heroManager;

    private void Start()
    {
        heroManager = FindObjectOfType<HeroManager>();
        CharmPlayer();
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
        Destroy(gameObject);
    }

}
