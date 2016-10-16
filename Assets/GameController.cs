using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Score score;
    public Timer time; 
    GameObject ui;
    GameObject endui;
    List<MonoBehaviour> maimPlayer; 

	// Use this for initialization
	void Start () {
        ui = GameObject.Find("UI");
        endui = GameObject.Find("EndGameUI");
        ui.SetActive(true);
        endui.SetActive(false);
        maimPlayer = new List<MonoBehaviour>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        maimPlayer.Add(player.GetComponent<Dash>());
        maimPlayer.Add(player.GetComponent<CharacterMovement>());
	}

    public void End(bool victory)
    {
        //disable the player
        foreach (var i in maimPlayer)
        {
            Destroy(i);
        }
        //toggle ui's
        ui.SetActive(false);
        endui.SetActive(true);
        //set a display message
        if (victory)
        {
            endui.GetComponentInChildren<Text>().text = "YOU KILLED THEM ALL";
        }
        //score posting
        endui.transform.FindChild("Text").FindChild("LittleText").GetComponent<Text>().text =
                score.getKills().ToString() + " KILLS IN " +
                ((int)(time.total_time - time.getTime())).ToString() + " SECONDS";
                //"TEST";
    }   
	
}
