using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastorellaTrigger : MonoBehaviour {

    public GameObject pastorella;

    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            pastorella.SetActive(true);
        }
    }
}
