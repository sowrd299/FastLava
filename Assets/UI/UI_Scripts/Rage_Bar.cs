using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rage_Bar : MonoBehaviour {

    public Slider rage_bar;
    private float rage;
    private double timer;

    public float GetRage()
    {
        return rage;
    }

    private void DecreaseRage()
    {
        if (timer >= 1)
        {
            rage -= 25;
            if (rage < 0)
                rage = 0;
            timer = 0;
        }
    }

    public bool vulnerable()
    {
        return rage < 60;
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
        timer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Player's Rage Amount 
        timer += Time.deltaTime;
        DecreaseRage();
        rage_bar.value = GetRage();
	}
}
