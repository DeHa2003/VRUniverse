using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DiactivateObj : MonoBehaviour
{
    [SerializeField] private Transform parentObj;

    private Hand hand;
    public void DiactivateHandObject(GameObject attachedObj, Hand hand)
    {
        hand.DetachObject(attachedObj, attachedObj.GetComponent<Throwable>().restoreOriginalParent);
        Destroy(attachedObj.GetComponent<Throwable>());
        Destroy(attachedObj.GetComponent<Rigidbody>());
        attachedObj.transform.parent = parentObj.parent;
    }
}
