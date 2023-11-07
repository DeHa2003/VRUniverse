using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PCAssembly pcAssembly;
    [SerializeField] private int maxscore;
    [SerializeField] private TextMeshProUGUI textScore;

    private int score = 0;
    public void Increase()
    {
        if (score < maxscore)
        {
            score += 1;
            textScore.text = score.ToString();
        }

        if (score == maxscore)
        {
            AudioManager.instance.PlaySounds(Sound.TypeAudio.CompletedGame);
            pcAssembly.CompletedTask();

            TaskManager taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskManager>();
            taskManager.Congratulations(); taskManager.Congratulations();
        }
    }
}