using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    Dash dash;
    public Text combo;
    private int comboValue;
    private double timer;
    // Use this for initialization

    public void AddCombo(int x)
    {
        comboValue += x;
    }
    public void resetTimer()
    {
        timer = 0;
    }
    void Start ()
    {
        combo.text = "";
        comboValue = 0;
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        combo.text = comboValue + " Combo";
        if (timer >= 1)
            comboValue = 0;
        else
            timer += Time.deltaTime;
    }
}
