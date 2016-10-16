using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

    // Use this for initialization
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((  playerPos.y-transform.position.y), ( playerPos.x- transform.position.x )) * Mathf.Rad2Deg - 90);
    }
}