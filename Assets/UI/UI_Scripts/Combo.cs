using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {
    
    public Text combo;
    public int comboValue;
    // Use this for initialization

    public void AddCombo(int x)
    {
        comboValue += x;
    }

    void Start ()
    {
        combo.text = "";
        comboValue = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        combo.text = comboValue + " Combo";
        if (GetComponent<Dash>().timeFromLastKill >= 1)
            comboValue = 0;
    }
}
