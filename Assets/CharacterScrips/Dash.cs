using UnityEngine;

using System.Collections;

public class Dash : MonoBehaviour {

    
    // Use this for initialization
    private float dashDistance;
    private float duration;
    private float dashTimer;
    private float dashSpeed;
    public int dashWidth;
    private float dashDirection;
    private Vector3 moveVector;
    public double timeFromLastKill;
	void Start () {
        dash(0,0.001f); //instantiates variables
    }
	
	// Update is called once per frame
	void Update () {    
	    if(dashTimer <= duration)
        {
            dashTimer += Time.deltaTime;
            print(dashTimer);
            transform.Translate(moveVector*Time.deltaTime);
        } 
	}

    public void dash(int distance, float duration)        //call this to dash in a direction for a distance in a certain time.  
    {                                                                              //duration = 1 for a single frame dash
        dashDistance = distance;
        
        this.duration = duration;
        dashTimer = 0;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xDiff = mousePos.x - transform.position.x;
        float yDiff = mousePos.y - transform.position.y;



        dashDirection = getAngle(xDiff, yDiff);
        if (duration > 1/60) { 
            dashSpeed = (distance / duration)/60;
        } else
        {
            dashSpeed = distance;
        }

        
        moveVector = new Vector3(dashSpeed * Mathf.Cos(dashDirection),  dashSpeed * Mathf.Sin(dashDirection),0);
        print(moveVector);
       // ArrayList enemyList = getCollisions((int)dashDistance, dashDirection, dashWidth);
        //killEnemies(enemyList);
    }

    

    public GameObject getPolygon(int dashDistance, float dashDirection, int dashWidth)
    {  //return a rectangular polygon that encompasses the entire dash movement

        Vector2[] pointList = new Vector2[4];

        //player's right side before dash, assuming facing up
        Vector2 playerLocation = transform.position;
        pointList[0] = playerLocation + new Vector2(polarX(dashWidth, dashDirection + 90),polarY(dashWidth,dashDirection + 90));
        //player's right side after dash
        pointList[1] = pointList[0] + new Vector2(polarX(dashDistance, dashDirection), polarY(dashDistance, dashDirection));
        //player's left side after dash
        pointList[2] = pointList[1] + new Vector2(polarX(dashWidth, dashDirection-90), polarY(dashWidth, dashDirection-90));
        //player's let side before dash
        pointList[3] = playerLocation + new Vector2(polarX(dashWidth, dashDirection - 90), polarY(dashWidth, dashDirection - 90));
        GameObject tempObject = new GameObject("tempObject");
        tempObject.AddComponent<PolygonCollider2D>();
        Vector2[] line = new Vector2[2];
        line[0] = pointList[0];
        line[1] = pointList[1];
        tempObject.GetComponent<PolygonCollider2D>().SetPath(0,line);
        line[0] = pointList[1];
        line[1] = pointList[2];
        tempObject.GetComponent<PolygonCollider2D>().SetPath(0, line);
        line[0] = pointList[2];
        line[1] = pointList[3];
        tempObject.GetComponent<PolygonCollider2D>().SetPath(0, line);
        line[0] = pointList[3];
        line[1] = pointList[0];
        tempObject.GetComponent<PolygonCollider2D>().SetPath(0, line);
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawLine(playerLocation, playerLocation + new Vector2(polarX(dashDistance, dashDirection), polarY(dashDistance, dashDirection)));
        return tempObject;

    }

    public ArrayList getCollisions(int dashDistance, float dashDirection, int dashWidth)  //return a list of all affected enemies
    {

        GameObject poly = getPolygon(dashDistance,dashDirection,dashWidth);


        ArrayList result = new ArrayList();
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            //if(poly.IsTouching())  need a way to reference enemy's Collider2D
            
        }
        return result;

    }
    public void killEnemies(ArrayList enemyList)
    {
        if(enemyList.Count != 0)         //marks time from last kill for combo duration purposes
        {
            timeFromLastKill = Time.time;
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            print("ENEMY WAS HIT");
            //TELL ENEMIES TO KILL THEMSELVES
        }
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
    {
        return (float)(System.Math.Atan2(yDiff, xDiff));
    }


    
   

}
