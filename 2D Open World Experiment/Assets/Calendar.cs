using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {
    public float yearCounter;
    public float monthCounter;
    public float dayCounter;
    public float hourCounter;
    public float MinuteCounter;
    public float secondsCounter;

    public float Year;
    public float Month;
    public float Day;
    public float Hour;
    public float Minute;
    public float Seconds;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        secondsCounter++;
        Seconds++;
        if (secondsCounter >= 60)
        {
            secondsCounter = 0;
            MinuteCounter++;
            Minute++;
        }
        if (MinuteCounter >= 60)
        {
            MinuteCounter = 0;
            hourCounter++;
            Hour++;
        }
        if (hourCounter >= 24)
        {
            dayCounter++;
            Day++;
        }
        if (dayCounter >= 30)
        {
            monthCounter++;
            Month++;
        }
        if (monthCounter >= 12)
        {
            yearCounter++;
            Year++;
        }
		
	}
}
