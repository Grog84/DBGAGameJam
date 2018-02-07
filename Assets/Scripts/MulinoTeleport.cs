using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulinoTeleport : MonoBehaviour {

    public GameObject[] links;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject farestLink = links[0];
            float dist = (farestLink.transform.position - transform.position).sqrMagnitude;
            if ((links[1].transform.position - transform.position).sqrMagnitude > dist)
            {
                farestLink = links[1];
            }
            other.transform.position = farestLink.transform.position;

        }
    }
}
