using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MulinoAvvento : MonoBehaviour {

    public void DestroyMulino()
    {
        transform.DOShakePosition(3f, fadeOut: true);
    }
}
