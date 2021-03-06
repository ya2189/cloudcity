﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Countdown Timer:
/// 
/// Displays countdown value on GUI
/// 
/// countdown- value countdown starts from
/// currCountdown- current countdown value
/// </summary>

public class CountdownTimer : MonoBehaviour
{
    public int countdown;
    public int currCountdown;
    private Text countdownText;
    private int minutes;
    private int seconds;
    public bool timeOut;

    IEnumerator Start()
    {
        timeOut = false;
    //    GameObject GameOverCanvas = GameObject.Find("GameOverCanvas"); //Find the gameobject that the script is attached to
    //    GameOverMenuTimeIn gameOverScript = GameOverCanvas.GetComponent<GameOverMenuTimeIn>(); //Access script by using GetComponent
    //    countdown = gameOverScript.timeout; //Now can access variables in script
        yield return StartCoroutine(StartCountdown(countdown));
    }

    IEnumerator StartCountdown(int countdown)
    {
        currCountdown = countdown;

        while (currCountdown >= 0)
        {
            //compute minutes from seconds if over 59 seconds
            if (currCountdown > 59)
            {
                minutes = currCountdown / 60;
                seconds = currCountdown - (minutes * 60);
            } else
            {
                minutes = 0;
                seconds = currCountdown;
            }
       
            countdownText = gameObject.GetComponent<Text>();

            if (seconds < 10 && minutes < 10)
            {
                //countdownText.text = "Time: 0" + minutes + " : 0" + seconds;
                countdownText.text = "0" + minutes + " : 0" + seconds;

            } else if (seconds < 10)
            {
                //countdownText.text = "Time: " + minutes + " : 0" + seconds;
                countdownText.text = "" + minutes + " : 0" + seconds;

            } else if (minutes < 10)
            {
                //countdownText.text = "Time: 0" + minutes + " : " + seconds
                countdownText.text = "0" + minutes + " : " + seconds;


            } else
            {
                //countdownText.text = "Time: " + minutes + " : " + seconds;
                countdownText.text = "" + minutes + " : " + seconds;

            }
            

            if (currCountdown <= 15)
            {
                countdownText.color = Color.red;
            }
            yield return new WaitForSeconds(1.0f);
            currCountdown--;

            /*if the current countdown number is below 0, set timeout flag to be true
             so that the gameovercanvas will appear*/
            if (currCountdown < 0)
            {
                timeOut = true;
            }
        }
    }
}
