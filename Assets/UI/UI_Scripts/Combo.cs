using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    public Text combo;
    public int comboValue;
	// Use this for initialization
	void Start ()
    {
        combo.text = "";
        comboValue = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
        combo.text = comboValue + " Combo";
    }
}
