using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftScript : MonoBehaviour
{
    Text text;
    public static float timeLeft = 300f;

    // Use this for initialization
    void Start ()
    {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            timeLeft = 0;
        text.text = "Time left: " + Mathf.Round(timeLeft);
    }
}
