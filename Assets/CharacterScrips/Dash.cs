using UnityEngine;

using System.Collections;

public class Dash : MonoBehaviour {

    
    // Use this for initialization
    private float dashDistance;
    private int duration;
    private float dashTimer;
    private float dashSpeed;
    public float dashWidth;
    private float dashDirection;
    private Vector3 moveVector;
    public double timeFromLastKill;
    


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

    public void dash(int distance, int duration)        //call this to dash in a direction for a distance in a certain time.  
    {
        //duration = 1 for a single frame dash
        
        dashDistance = distance;
        dashWidth = 0.1f;
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

    public void getBoxCast()
    {
        RaycastHit2D[] boxCastAll;
        boxCastAll = Physics2D.BoxCastAll(transform.position, new Vector2(dashWidth,dashWidth), Mathf.Rad2Deg*dashDirection,new Vector2(Mathf.Cos(dashDirection),Mathf.Sin(dashDirection)), dashDistance);
        
        for(int i = 0; i < boxCastAll.Length; i++)
        {
            if (boxCastAll[i].collider.gameObject.tag == "Enemy")
            {
                killEnemy(boxCastAll[i].collider.gameObject);

            }
        }

            
        

    }
    public void boxCastAroundPlayer()
    {
        RaycastHit2D[] boxCastAll;
        boxCastAll = Physics2D.BoxCastAll(transform.position, new Vector2(1.5f, 1.5f), Mathf.Rad2Deg * dashDirection, 
            new Vector2(Mathf.Cos(dashDirection), Mathf.Sin(dashDirection)), 0.0001f);

        for (int i = 0; i < boxCastAll.Length; i++)
        {
            if (boxCastAll[i].collider.gameObject.tag == "Enemy")
            {
                killEnemy(boxCastAll[i].collider.gameObject);
            
            }
        }
    }
    
    public void killEnemy(GameObject enemy)
    {
       
        timeFromLastKill = Time.time;
        enemy.GetComponent<Killable>().Hit();
        GetComponent<Rage_Bar>().AddRage(enemy.GetComponent<Killable>().rageVal);


            //GetComponent<Rage_Bar>().addRage
        

        
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
