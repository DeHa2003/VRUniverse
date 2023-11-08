using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class NameObj : MonoBehaviour
{
    [SerializeField] private string nameString;
    [SerializeField] private GameObject textObj;

    private TextMeshPro textName;

    private void Awake()
    {
        textName = textObj.GetComponent<TextMeshPro>();
    }

    public void ShowNameObject()
    {
        textName.text = nameString;
        textObj.SetActive(true);
        textObj.transform.LookAt(Camera.main.transform);
        textObj.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
    }

    public void HideNameObject()
    {
        textObj.SetActive(false);
    }

    
    //gameObject.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
    

    
}
