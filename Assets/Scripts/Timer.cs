using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GM gm;
    public TextMeshProUGUI timerText;
    float totalTime = 120f; //2 min
    
    public void Update()
    {
        if( gm.isPlaying){
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime);
        }
        if (totalTime <= 0)
        {
            gm.GameOver();
            UpdateLevelTimer(0);
        }
    }
 
    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
 
        // string formatedSeconds = seconds.ToString();
 
        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
