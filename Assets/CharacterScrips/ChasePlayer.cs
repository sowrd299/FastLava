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
    private bool activated;
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
        if (!activated)
        {
            distanceToPlayer = Vector2.Distance((Vector2)(transform.position), (Vector2)(player.transform.position));
        } else
        {
            angleToPlayer = getAngleToPlayer();
            transform.Translate((speed * Mathf.Cos(angleToPlayer)) * Time.deltaTime, (speed * Mathf.Sin(angleToPlayer)) * Time.deltaTime, 0);
        }
        if (distanceToPlayer < runRadius && !activated)
        {
            activated = true;
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
