using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerRazborka : MonoBehaviour
{
    public TextMeshProUGUI numberStepUI;
    public TextMeshProUGUI numberPopitkiUI;
    public GameObject errorText;

    public int numberStepThisObj;
    public GameObject doubleThis;

    private Hand hand;
    private int a;

    public GameObject twoUI;
    public GameObject threeUI;
    public GameObject fourUI;

    private TaskManager taskManager;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == doubleThis)
        {

            hand = doubleThis.transform.parent.GetComponent<Hand>();
            taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskManager>();

            taskManager.spawners.Add(doubleThis);

            if (numberStepThisObj == int.Parse(numberStepUI.text))
            {
                a = int.Parse(numberStepUI.text);
                if(a < 4)
                {
                    a += 1;
                    numberStepUI.text = a.ToString();
                }
                else
                {
                    doubleThis.transform.SetPositionAndRotation(transform.position, transform.rotation);
                    taskManager.Congratulations();
                }

                doubleThis.GetComponent<Rigidbody>().isKinematic = false;
                doubleThis.GetComponent<Rigidbody>().useGravity = true;
                switch (int.Parse(numberStepUI.text))
                {
                    case 2:
                        twoUI.SetActive(true);
                        break;
                    case 3:
                        threeUI.SetActive(true);
                        break;
                    case 4:
                        fourUI.SetActive(true);
                        break;
                }

                Destroy(gameObject);
            }
            else
            {
                doubleThis.GetComponent<Rigidbody>().isKinematic = true;
                hand.DetachObject(doubleThis, doubleThis.GetComponent<Throwable>().restoreOriginalParent);
                doubleThis.transform.SetPositionAndRotation(transform.position, transform.rotation);

                a = int.Parse(numberPopitkiUI.text);
                if(a == 0)
                {
                    taskManager.BackTask();
                }
                else
                {
                    a -= 1;
                    numberPopitkiUI.text = a.ToString();
                }

                StartCoroutine(ErrorVisible());
            }
        }
    }

    IEnumerator ErrorVisible()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(1);
        errorText.SetActive(false);
    }
}
