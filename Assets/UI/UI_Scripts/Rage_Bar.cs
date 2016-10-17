using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rage_Bar : MonoBehaviour {

    public float InvolThres = 85;
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
            rage -= 7.5f * Time.deltaTime;
        else
            rage -= 2.5f * Time.deltaTime;
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
            fill.color = new Color(1, 0.5f * (100 - rage) / (100 - InvolThres), 0);///Color.red;
        else
            fill.color = Color.cyan;
    }
}
