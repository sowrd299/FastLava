using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    private float closeBy
    {
        //what fraction of the distance to close
        get
        {
            if(Vector2.Distance(transform.position,player.transform.position) < 0.1)
            {
                //if nearby, snap
                return 1;
            }
            return (1f / 7f);
        }
    }

    public bool closed
    {
        get
        {
            return (Vector2)transform.position == (Vector2)player.transform.position;
        }    
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + (player.transform.position - transform.position) * closeBy;
	}
}
