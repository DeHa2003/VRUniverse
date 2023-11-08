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
            other.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            destroyObj.DiactivateHandObject(other.gameObject);

            score.Increase();
            textTaskDone.TaskDone();
            Destroy(gameObject);
        }
    }
}
