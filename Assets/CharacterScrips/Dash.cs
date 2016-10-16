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
    public float explodeRadius = 3;
    private Vector3 moveVector;
    public double timeFromLastKill;

	public Animator dashing;
    public FaceMouse faceMouse;
    private int idleAnimeState;
   
    private Vector2 angle;
    private bool debug;

    Combo combo;
    Rage_Bar rage;
    Score score;


	void Start () {
        dashDistance = 0;
        dashWidth = 0.30f;

        this.duration = 0;
        dashTimer = 0;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xDiff = mousePos.x - transform.position.x;
        float yDiff = mousePos.y - transform.position.y;



        dashDirection = getAngle(xDiff, yDiff);
        dashSpeed = dashDistance;

        faceMouse = transform.GetComponentInChildren<FaceMouse>();
        idleAnimeState = dashing.GetCurrentAnimatorStateInfo(0).fullPathHash;

        moveVector = new Vector3(dashSpeed * Mathf.Cos(dashDirection), dashSpeed * Mathf.Sin(dashDirection), 0);
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
        if (dashing.GetCurrentAnimatorStateInfo(0).fullPathHash == idleAnimeState)
        {
            faceMouse.enabled = true;
            Debug.Log("Canceling animaition");
        }
        else
        {
            Debug.Log("Allowing to continue to play animation.");
        }

	}


    public void dash(float distance, int duration)        //call this to dash in a direction for a distance in a certain time.  
    {                                                                              //duration = 1 for a single frame dash
		dashing.Play("DashAnimation");
		dashDistance = distance;
        dashWidth = 0.30f;

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
		dashing.SetBool ("spinattack", true);
        faceMouse.enabled = false;
		dashing.Play ("spinattack");
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

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        score.AddKills(1);
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
