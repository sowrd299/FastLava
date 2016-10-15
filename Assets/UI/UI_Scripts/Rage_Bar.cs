using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rage_Bar : MonoBehaviour {

    public GameObject player;
    public Slider rage_bar;
    public float rage;

    public float GetRage()
    {
        return rage;
    }

    public void AddRage(int x)
    {
        rage += x;
    }

    void Start ()
    {

        rage_bar.maxValue = 100;
        rage_bar.minValue = 0;
        rage = 0;
        rage_bar.value = rage;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Player's Rage Amount 
        rage_bar.value = GetRage();
	}
}
