using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAnimationRoblin : DirectionAnimation
{

    public override void Awake()
    {
        base.Awake();
        m_Animator = transform.FindDeepChild("Skin").GetComponent<Animator>();
    }
}
