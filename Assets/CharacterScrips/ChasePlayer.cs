using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    private Vector2 playerLocation;
    private float angleToPlayer;
    private float distanceToPlayer;
    public float runRadius;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        angleToPlayer = getAngleToPlayer();
        runRadius = (float)(runRadius + Random.value * 3 - 1.5);
        speed = (float)(speed + Random.value * 0.45 - 0.9);

    }

    // Update is called once per frame

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < runRadius)
        {
            angleToPlayer = getAngleToPlayer();
            transform.Translate((speed * Mathf.Cos(angleToPlayer)) * Time.deltaTime, (speed * Mathf.Sin(angleToPlayer )) * Time.deltaTime, 0);

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
