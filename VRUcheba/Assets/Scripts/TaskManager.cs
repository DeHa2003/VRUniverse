using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject backTask;

    private GameObject numberTaskUI;
    private GameObject task;

    private GameObject congratFinishText;

    public List<GameObject> spawners = new List<GameObject>();
    public void PlayTask(GameObject numberTaskUI2)
    {
        congratFinishText = numberTaskUI2.transform.GetChild(3).gameObject;
        numberTaskUI = numberTaskUI2.transform.GetChild(0).gameObject;
        numberTaskUI.SetActive(false);
        backTask.SetActive(true);
    }

    public void SpawnTask(GameObject task2)
    {
        if (numberTaskUI != null && task != null)
        {
            BackTask();
        }

        task = Instantiate(task2);
    }

    public void BackTask()
    {
        numberTaskUI.SetActive(true);
        Destroy(task);
        backTask.SetActive(false);

        for (int i = 0; i < spawners.Count; i++)
        {
            Destroy(spawners[i]);
        }
        spawners.Clear();
    }

    public void Congratulations()
    {
        congratFinishText.SetActive(true);
        Destroy(numberTaskUI);
        Destroy(task);
        backTask.SetActive(false);

        for (int i = 0; i < spawners.Count; i++)
        {
            Destroy(spawners[i]);
        }
        spawners.Clear();
    }
}
