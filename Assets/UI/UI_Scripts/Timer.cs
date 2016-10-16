using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float total_time;
    private DiesToLava dies;
    private float time_passed;
    public Text timer;

    // Use this for initialization
	void Start ()
    {
        dies = GameObject.FindGameObjectWithTag("Player").GetComponent<DiesToLava>();
        time_passed = 0f;
        timer.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_passed =  total_time - Time.time;
        timer.text = time_passed.ToString();
        if (time_passed <= 0)
            dies.Die();
	}

    public float getTime()
    {
        return time_passed;
    }
}
