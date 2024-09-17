using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerCounter : MonoBehaviour
{
    public TMP_Text timerText;

    private bool isCounting = false;
    private float countTime = 0;

    private void OnEnable()
    {
        StartTimer();
    }

    void Update()
    {
        if (isCounting)
        {
            countTime += Time.deltaTime;
            timerText.text = TimerFormatter(countTime);
        }       
    }

    private void OnDisable()
    {
        StopTimer();
    }

    string TimerFormatter(float time)
    {
        int hour = (int)(time / 3600);
        int min = (int)(time - hour * 3600) / 60;
        int sec = (int)(time - hour * 3600 - min * 60);
        return min.ToString("D2") + ":" + sec.ToString("D2");
    }

    void StartTimer()
    {
        isCounting = true;
    }

    void StopTimer()
    {
        isCounting = false;
        countTime = 0;
    }
}
