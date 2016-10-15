using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    public Text combo;
	// Use this for initialization
	void Start ()
    {
        combo.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        combo.text = 20.ToString() + " Combo";
	}
}
