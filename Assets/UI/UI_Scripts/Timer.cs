using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float total_time = 50f;
    private DiesToLava dies;
    private float time_passed;
    public Text timer;

    // Use this for initialization
	void Start ()
    {
        dies = GameObject.FindGameObjectWithTag("Player").GetComponent<DiesToLava>();
        time_passed = total_time;
        timer.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_passed =  time_passed - Time.deltaTime;
        timer.text = time_passed.ToString();
        if (time_passed <= 0)
            dies.Die();
	}

    public void resetTime()
    {
        time_passed = total_time;
    }

    public float getTime()
    {
        return time_passed;
    }
}
