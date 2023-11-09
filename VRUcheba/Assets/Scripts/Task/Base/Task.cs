using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] protected List<GameObject> VRObjects;
    [SerializeField] protected DiactivateVRObject diactivateObjs;
    public virtual void CompletedTask()
    {
        TaskUIManager taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskUIManager>();
        taskManager.Congratulations();

        foreach (var item in VRObjects)
        {
            diactivateObjs.DetachObject(item);
            Destroy(item);
        }
        Destroy(gameObject);
    }
}
