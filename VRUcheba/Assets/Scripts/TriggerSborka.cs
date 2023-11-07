using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerSborka : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextTaskDone textTaskDone;
    [SerializeField] private DiactivateObj destroyObj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(gameObject.tag))
        {
            destroyObj.DiactivateHandObject(other.gameObject, other.transform.parent.GetComponent<Hand>());
            other.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);

            score.Increase();
            textTaskDone.TaskDone();
            Destroy(gameObject);
        }
    }
}
