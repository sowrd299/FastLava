using UnityEngine;
using System.Collections;

public class FaceAwayFromPlayer : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPos = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(( transform.position.y-playerPos.y), (transform.position.x- playerPos.x)) * Mathf.Rad2Deg - 90);
    }
}
