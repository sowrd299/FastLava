using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float total_time = 120;
    private float time_passed;
    public Text timer;

    // Use this for initialization
	void Start ()
    {
        time_passed = 0f;
        timer.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_passed =  total_time - Time.time;
        timer.text = time_passed.ToString();
	}

    public float getTime()
    {
        return time_passed;
    }
}
