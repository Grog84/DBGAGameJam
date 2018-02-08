using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour {

    [FMODUnity.EventRef]
    public string m_EventPath;

    public void PlaySound()
    {
        if (m_EventPath != null)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
            //e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            e.start();
            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }

}
