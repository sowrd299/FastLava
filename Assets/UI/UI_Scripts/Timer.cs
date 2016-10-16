using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

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
        time_passed = 240 - Time.time;
        timer.text = time_passed.ToString();
	}
}
