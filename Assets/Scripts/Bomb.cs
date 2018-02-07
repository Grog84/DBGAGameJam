using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    [Range(1, 10)]
    public int numberOfRequiredTap = 3;
    public int numberOfTap = 0;

    private void OnMouseDown()
    {
        numberOfTap++;
    }

    private void Explode()
    {

    }

    private void Update()
    {
        if (numberOfTap > numberOfRequiredTap)
        {

        }
    }



}
