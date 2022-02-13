using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{

    private static DateTime startTime = DateTime.MinValue;

    bool stopWatchActive = true;
    public Text currentTimeText;


    void Start()
    {
        if(startTime== DateTime.MinValue)
        {
            startTime = DateTime.Now;
        }
    }

    void FixedUpdate()
    {
        if (stopWatchActive == true)
        {
            TimeSpan time = DateTime.Now.Subtract(startTime);
            currentTimeText.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + ":" + time.Milliseconds.ToString("000").Substring(0,2);
        }
        
    }

    public void StartStopwatch()
    {
        stopWatchActive = true;
    }

    public void StopStopwatch()
    {
        stopWatchActive = false;
    }

}
