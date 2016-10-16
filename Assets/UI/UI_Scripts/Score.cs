using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text kills;
    private int killValue;

    public void AddKills(int x)
    {
        killValue += x;
    }

    // Use this for initialization
    void Start ()
    {
        kills.text = "";
        killValue = 0; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        kills.text = killValue + " Kills";
	}

    public int getKills()
    {
        return killValue;
    }
}
