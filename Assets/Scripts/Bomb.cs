using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    [Range(1, 10)]
    public int numberOfRequiredTap = 3;
    [HideInInspector] public int numberOfTap = 0;

    public GameObject explosion;
    SpriteRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        numberOfTap++;
    }

    private void Explode()
    {
        explosion.SetActive(true);
    }

    private void Update()
    {
        if (numberOfTap > numberOfRequiredTap)
        {
            m_Renderer.enabled = false;
            Explode();

        }
        if (numberOfTap == -1)
        {
            Destroy(gameObject);
        }
    }

    

}
