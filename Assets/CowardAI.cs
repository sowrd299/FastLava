﻿using UnityEngine;
using System.Collections;

public class CowardAI : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    private Vector2 playerLocation;
    private float angleToPlayer;
    private float distanceToPlayer;
    public float runRadius;
    public float speed;
    public float fireRate;
    public float fireTimer;
    public float bulletSpeed;
    private bool activated;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        angleToPlayer = getAngleToPlayer();
        runRadius = (float)(runRadius + Random.value * 3 - 1.5);
        speed = (float)(speed + Random.value * 0.45 - 0.9);
        fireTimer = fireRate;

    }

    // Update is called once per frame

    void Update () {
        if (!activated)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < runRadius)
            {
                activated = true;
            }
        } else 
        {
            angleToPlayer = getAngleToPlayer();
            transform.Translate((speed * Mathf.Cos(angleToPlayer+Mathf.PI)) *Time.deltaTime, (speed * Mathf.Sin(angleToPlayer+Mathf.PI))*Time.deltaTime,0);
            if(fireTimer > 0)
            {
                fireTimer-= Time.deltaTime;
            } else
            {
                
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
                bullet.transform.position = transform.position + new Vector3(polarX(0.5f, angleToPlayer-Mathf.PI/8), polarY(0.5f, angleToPlayer - Mathf.PI / 8),0);
                bullet.GetComponent<BulletMovement>().setDirection(angleToPlayer);
                bullet.GetComponent<BulletMovement>().setSpeed(bulletSpeed);
                bullet.GetComponent<BulletMovement>().calculateMoveVector();
                bullet.GetComponentInChildren<RotateToAngle>().setAngle(transform.FindChild("Sprite").transform.rotation);
                

                GameObject bullet2 = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
                bullet2.transform.position = transform.position + new Vector3(polarX(0.5f, angleToPlayer - Mathf.PI / 8), polarY(0.5f, angleToPlayer - Mathf.PI / 8), 0);
                bullet2.GetComponent<BulletMovement>().setDirection(angleToPlayer+Mathf.PI/8);
                bullet2.GetComponent<BulletMovement>().setSpeed(bulletSpeed);
                bullet2.GetComponent<BulletMovement>().calculateMoveVector();
                bullet2.GetComponentInChildren<RotateToAngle>().setAngle(transform.FindChild("Sprite").transform.rotation);


                GameObject bullet3 = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
                bullet3.transform.position = transform.position + new Vector3(polarX(0.5f, angleToPlayer - Mathf.PI / 8), polarY(0.5f, angleToPlayer - Mathf.PI / 8), 0);
                bullet3.GetComponent<BulletMovement>().setDirection(angleToPlayer - Mathf.PI / 8);
                bullet3.GetComponent<BulletMovement>().setSpeed(bulletSpeed);
                bullet3.GetComponent<BulletMovement>().calculateMoveVector();
                bullet3.GetComponentInChildren<RotateToAngle>().setAngle(transform.FindChild("Sprite").transform.rotation);


                fireTimer = fireRate;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Lava")
            Destroy(gameObject);

    }
    public float getAngleToPlayer()  //returns the angle from a given xDiff and yDiff
    {  //returns radian
        playerLocation = player.transform.position;
        float xDiff = playerLocation.x - transform.position.x;
        float yDiff = playerLocation.y - transform.position.y;
        
        return (float)(System.Math.Atan2(yDiff, xDiff));
    }
    private float polarX(float distance, float angle)  //returns x coord of a distance in a given direction
    {
        return (float)(distance * System.Math.Cos(angle));
    }

    private float polarY(float distance, float angle)  //returns y coord of a distance in a given direction
    {
        return (float)(distance * System.Math.Sin(angle));
    }
}
