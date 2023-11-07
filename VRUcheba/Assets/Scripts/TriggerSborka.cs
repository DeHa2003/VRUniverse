using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerSborka : MonoBehaviour
{
    public GameObject galka;
    public TextMeshProUGUI schet;
    public GameObject canvas;

    private int a;
    private GameObject attachedObj;
    private Hand hand;

    public GameObject prefabPC;
    public GameObject parentPC;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(gameObject.tag))
        {
            attachedObj = other.gameObject;
            hand = attachedObj.transform.parent.GetComponent<Hand>();

            //+1
            a = int.Parse(schet.text);
            a += 1;
            schet.text = a.ToString();

            galka.SetActive(true);
            hand.DetachObject(attachedObj, attachedObj.GetComponent<Throwable>().restoreOriginalParent);
            Destroy(attachedObj.GetComponent<Throwable>());
            Destroy(attachedObj.GetComponent<Rigidbody>());
            other.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            attachedObj.transform.parent = parentPC.transform;

            //
            if (a == 5)
            {
                Instantiate(prefabPC, parentPC.transform.position, parentPC.transform.rotation);
                Destroy(canvas);
                Destroy(parentPC);

                TaskManager taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskManager>();
                taskManager.Congratulations();
            }

            Destroy(gameObject);
        }
    }
}
