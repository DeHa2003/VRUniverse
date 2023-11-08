using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTaskUI : TaskUI
{
    [SerializeField] private GameObject textProcessing;

    public override void Play()
    {
        base.Play();
        textProcessing.transform.Rotate(new Vector3(0, 0, Random.Range(-30f, 30f)));
        textProcessing.SetActive(true);
    }

    public override void Congratulate()
    {
        base.Congratulate();
        Destroy(textProcessing);
    }

    public override void Cancel()
    {
        base.Cancel();
        textProcessing.SetActive(false);
    }
}
