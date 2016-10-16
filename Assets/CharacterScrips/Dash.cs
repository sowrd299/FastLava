﻿using UnityEngine;

using System.Collections;

public class Dash : MonoBehaviour {

    
    // Use this for initialization
    private float dashDistance;
    private int duration;
    private float dashTimer;
    private float dashSpeed;
    public float dashWidth;
    private float dashDirection;
    public float explodeRadius = 3;
    private Vector3 moveVector;
    public double timeFromLastKill;
    Combo combo;
    Rage_Bar rage;


	void Start () {
        dash(0,1); //instantiates variables
        
    }
	
	// Update is called once per frame
	void Update () {    
	    if(dashTimer < duration)
        {
            dashTimer += 1;
            getBoxCast();
            boxCastAroundPlayer();
            transform.Translate(moveVector);
            boxCastAroundPlayer();
            
        } 
	}

    public void dash(float distance, int duration)        //call this to dash in a direction for a distance in a certain time.  
    {
        //duration = 1 for a single frame dash
        
        dashDistance = distance;
        
        this.duration = duration;
        dashTimer = 0;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xDiff = mousePos.x - transform.position.x;
        float yDiff = mousePos.y - transform.position.y;
    
        

        dashDirection = getAngle(xDiff, yDiff);
        dashSpeed = dashDistance;

        
        moveVector = new Vector3(dashSpeed * Mathf.Cos(dashDirection),  dashSpeed * Mathf.Sin(dashDirection),0);
        
       //ArrayList enemyList = getCollisions((int)dashDistance, dashDirection, dashWidth);
        //killEnemies(enemyList);
    }

    public void Explode()
    {
        //kill all things near player
        murderAll(Physics2D.OverlapCircleAll(transform.position, explodeRadius));
    }

    public void getBoxCast()
    {
        RaycastHit2D[] boxCastAll;
        boxCastAll = Physics2D.BoxCastAll(transform.position, new Vector2(dashWidth, dashWidth), Mathf.Rad2Deg * dashDirection, new Vector2(Mathf.Cos(dashDirection), Mathf.Sin(dashDirection)), dashDistance);
        murderCast(boxCastAll);
    }   
        

    public void boxCastAroundPlayer()
    {
        RaycastHit2D[] boxCastAll;
        boxCastAll = Physics2D.BoxCastAll(transform.position, new Vector2(1.5f, 1.5f), Mathf.Rad2Deg * dashDirection, 
            new Vector2(Mathf.Cos(dashDirection), Mathf.Sin(dashDirection)), 0.0001f);
        murderCast(boxCastAll);
    }

    private void murderCast(RaycastHit2D[] hits)
    {
        Collider2D[] r = new Collider2D[hits.Length];
        for(int i = 0; i < hits.Length; ++i)
        {
            r[i] = hits[i].collider;
        }
        murderAll(r);
    }

    private void murderAll(Collider2D[] hits) {
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Enemy")
            {
                killEnemy(hits[i].gameObject);

            }
        }
    }
    
    public void killEnemy(GameObject enemy)
    {
       
        timeFromLastKill = 0;
        enemy.GetComponent<Killable>().Hit();
        rage = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
        rage.AddRage(enemy.GetComponent<Killable>().rageVal);
        
        combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<Combo>();
        combo.AddCombo(1);
        combo.resetTimer();

    }

    


    private float polarX(float distance, float angle)  //returns x coord of a distance in a given direction
    {  
        return (float)(distance * System.Math.Cos(angle));  
    }

    private float polarY(float distance, float angle)  //returns y coord of a distance in a given direction
    {
        return (float)(distance * System.Math.Sin(angle));
    }

    public float getAngle(float xDiff, float yDiff)  //returns the angle from a given xDiff and yDiff
    {  //returns radian
        return (float)(System.Math.Atan2(yDiff, xDiff));
    }

    public double getTimeSinceLastKill()
    {
        return timeFromLastKill;
    }


}
