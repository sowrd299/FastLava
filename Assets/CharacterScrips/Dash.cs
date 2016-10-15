using UnityEngine;

using System.Collections;

public class Dash : MonoBehaviour {

    
    // Use this for initialization
    public float dashDistance;
    public float duration;
    public GameObject player;
    private float dashTimer;
    private float dashDirection;
    private Vector2 moveVector;
    public double timeFromLastKill;
	void Start () {
        dash(0, 0, 0); //instantiates variables
    }
	
	// Update is called once per frame
	void Update () {    
	    if(dashTimer < duration)
        {
            dashTimer += Time.deltaTime;
            player.transform.Translate(moveVector*Time.deltaTime);     //Not sure I'm using time.deltatime correctly here       
        }
	}

    public void dash(int dashDistance, float dashDirection, float duration)        //call this to dash in a direction for a distance in a certain time.  
    {                                                                              //duration = 1 for a single frame dash
        dashTimer = 0;
        
        float xDiff = Input.mousePosition.x - player.transform.position.x;
        float yDiff = Input.mousePosition.y - player.transform.position.y;
        dashDirection = getAngle(xDiff, yDiff);


        float stepDistance = dashDistance * (dashTimer / duration);   //div by zero if duration is zero
        moveVector = new Vector2(stepDistance * Mathf.Cos(dashDirection), stepDistance * Mathf.Sin(dashDirection));

        RectTransform playerRect = (RectTransform)player.transform;
        int playerWidth = (int)playerRect.rect.width;

        ArrayList enemyList = getCollisions((int)dashDistance, dashDirection, playerWidth);
        killEnemies(enemyList);
    }

    

    public PolygonCollider2D getPolygon(int dashDistance, float dashDirection, int playerWidth)
    {  //return a rectangular polygon that encompasses the entire dash movement

        Vector2[] pointList = new Vector2[4];

        //player's right side before dash, assuming facing up
        pointList[0] = new Vector2(polarX(playerWidth, dashDirection + 90),polarY(playerWidth,dashDirection + 90));
        //player's right side after dash
        pointList[1] = pointList[0] + new Vector2(polarX(dashDistance, dashDirection), polarY(dashDistance, dashDirection));
        //player's left side after dash
        pointList[2] = pointList[1] + new Vector2(polarX(playerWidth, dashDirection-90), polarY(playerWidth, dashDirection-90));
        //player's let side before dash
        pointList[3] = new Vector2(polarX(playerWidth, dashDirection - 90), polarY(playerWidth, dashDirection - 90));
    
        PolygonCollider2D result = new PolygonCollider2D();
        Vector2[] line = new Vector2[2];
        line[0] = pointList[0];
        line[1] = pointList[1];
        result.SetPath(0,line);
        line[0] = pointList[1];
        line[1] = pointList[2];
        result.SetPath(1,line);
        line[0] = pointList[2];
        line[1] = pointList[3];
        result.SetPath(2, line);
        line[0] = pointList[3];
        line[1] = pointList[0];
        result.SetPath(3, line);
        return result;

    }

    public ArrayList getCollisions(int dashDistance, float dashDirection, int playerWidth)  //return a list of all affected enemies
    {

        PolygonCollider2D poly = getPolygon(dashDistance,dashDirection,playerWidth);


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
        return (float)(System.Math.Atan2(yDiff, xDiff) * 180.0 / System.Math.PI);
    }


    
   

}
