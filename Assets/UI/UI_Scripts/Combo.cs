using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    Dash dash;
    public Text combo;
    private int comboValue;
    // Use this for initialization

    public void AddCombo(int x)
    {
        comboValue += x;
    }

    void Start ()
    {
        //combo = GetComponent<Text>();
        combo.text = "";
        comboValue = 0;
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
  
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        combo.text = comboValue + " Combo";
        if (dash.getTimeSinceLastKill() >= 1)
            comboValue = 0;
    }
}
