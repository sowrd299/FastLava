using UnityEngine;
using System.Collections;

public class CowardAI : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    private Vector2 playerLocation;
    private float angleToPlayer;
    private float distanceToPlayer;
    public float runRadius;
    public float speed;

	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        angleToPlayer = getAngleToPlayer();
        speed = 0.5f;
        

    }

    // Update is called once per frame

    void Update () {
        angleToPlayer = getAngleToPlayer();
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < runRadius)
        {
            transform.Translate(speed * Mathf.Cos(angleToPlayer + Mathf.PI / 2), speed * Mathf.Sin(angleToPlayer + Mathf.PI / 2),0);

        }
    }
    public float getAngleToPlayer()  //returns the angle from a given xDiff and yDiff
    {  //returns radian
        playerLocation = player.transform.position;
        float xDiff = playerLocation.x - transform.position.x;
        float yDiff = playerLocation.y - transform.position.y;
        
        return (float)(System.Math.Atan2(yDiff, xDiff));
    }
}
