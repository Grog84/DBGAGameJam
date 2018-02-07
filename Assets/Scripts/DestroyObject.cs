using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    MouseDrag barrel;

    private void Awake()
    {
        barrel = transform.parent.GetComponent<MouseDrag>();
    }
    void Death()
    {
        Destroy(barrel.thisObj);
    }
}
