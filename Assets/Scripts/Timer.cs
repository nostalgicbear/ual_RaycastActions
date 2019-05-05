using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public float seconds = 0; //This holds the total number of seconds that 
    public bool increaseTime = true; //The time will only increase if this is set to true

    public Text timerText; //The UI element that will display the total seconds

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

    private void RunTimer()
    {       
        if (increaseTime == true) //Check to see if increase time is TRUE. If it is , we increae the time. This gives you control over whether or not you want to increase the total number of seconds for something
        {
            seconds += Time.deltaTime; 
            timerText.text = seconds.ToString();
        }
    }
}
