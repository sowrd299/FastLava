using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rage_Bar : MonoBehaviour {

    public GameObject player;
    public Slider rage_bar;
    
    int Calculate_Rage()
    {
        return 50;
    }

    void Start ()
    {

        rage_bar.maxValue = 100;
        rage_bar.minValue = 0;
        rage_bar.value = 0;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Player's Rage Amount 
        rage_bar.value = Calculate_Rage();
        
	}
}
