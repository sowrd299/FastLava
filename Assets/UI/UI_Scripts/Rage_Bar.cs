using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rage_Bar : MonoBehaviour {

    public float InvolThres = 80;
    public Slider rage_bar;
    private float rage;
    public Image fill;

    public float GetRage()
    {
        return rage;
    }

    private void DecreaseRage()
    {
        if (rage > InvolThres)
            rage -= 20 * Time.deltaTime;
        else
            rage -= 5 * Time.deltaTime;
        if (rage < 0)
            rage = 0;
        if (rage > 100)
            rage = 100;
    }

    public bool vulnerable()
    {
        return rage < InvolThres;
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
        DecreaseRage();
        rage_bar.value = rage;
        if (!vulnerable())
            fill.color = Color.red;
        else
            fill.color = Color.cyan;
    }
}
