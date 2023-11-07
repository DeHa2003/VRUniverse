using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class NameObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckNameObj();
    }

    private void CheckNameObj()
    {
        if(gameObject.GetComponent<Interactable>().isHovering == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        }
        else
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Invoke(nameof(CheckNameObj), 1);
    }

    
}
