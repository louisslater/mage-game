using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//class to track time since game last reset
public class Timer : MonoBehaviour
{
    
    private static DateTime startTime = DateTime.MinValue;//track the start time

    bool stopWatchActive = true;
    public Text currentTimeText;//formatted time since start


    void Start()
    {
        if(startTime== DateTime.MinValue)//set this once
        {
            startTime = DateTime.Now;
        }
    }

    void FixedUpdate()
    {

        //update time on screen
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
        TimeSpan time = DateTime.Now.Subtract(startTime);
        currentTimeText.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + ":" + time.Milliseconds.ToString("000").Substring(0, 2);
        stopWatchActive = false;
    }

}
