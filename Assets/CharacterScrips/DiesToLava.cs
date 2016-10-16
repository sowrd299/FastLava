using UnityEngine;
using UnityEngine.SceneManagement;

public class DiesToLava : MonoBehaviour {

    //a spript for managing the characters reaction to terrains
    Rage_Bar rb;
    GameController gc;
    private bool wasVulnerable;
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        wasVulnerable = true;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Lava" && Vulnerable())
        {
            Die();
        }
        else if(c.gameObject.tag == "Victory")
        {
            gc.End(true);
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {   
        if (coll.gameObject.tag == "Lava" && Vulnerable())
        {
            Die();
            
        }
        else if (coll.gameObject.tag == "Victory")
        {
            gc.End(true);
        }    
    }
    void Update()
    {
        if(Vulnerable() && !wasVulnerable)
        {
            GameObject x = GameObject.FindGameObjectWithTag("Lava");
            x.GetComponent<PolygonCollider2D>().bounds.Contains(transform.position);
        }
        wasVulnerable = Vulnerable();
        
    }
    public bool Die()
    {
        ///returns true if player dies.
        Debug.Log("I am dead!");
        gc.End(false);
        return true;
    }

    public bool Vulnerable()
    {
        ///returns true if player able to die
        return rb.vulnerable();
    }

}
