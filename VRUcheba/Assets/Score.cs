using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] protected Task task;
    [SerializeField] protected int maxscore;
    [SerializeField] protected TextMeshProUGUI textScore;

    public int ScoreCount { get; private set; }
    protected void Awake()
    {
        ScoreCount = 0;
    }
    public virtual void Increase()
    {
        if (ScoreCount < maxscore)
        {
            ScoreCount += 1;
            textScore.text = ScoreCount.ToString();
        }

        if (ScoreCount == maxscore)
        {
            AudioManager.instance.PlaySounds(Sound.TypeAudio.CompletedGame);


            task.CompletedTask();


            TaskUIManager taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskUIManager>();
            taskManager.Congratulations();
        }
    }
}