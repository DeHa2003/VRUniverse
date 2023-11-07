using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerPSU : MonoBehaviour
{
    public GameObject PSUCover;
    public GameObject PSURazbor;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(gameObject.tag))
        {
            if (gameObject.CompareTag("PSU"))
            {
                PSUCover.AddComponent<Throwable>();
                PSURazbor.SetActive(true);
            }
        }
    }
}
