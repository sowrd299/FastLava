using UnityEngine;
using UnityEngine.SceneManagement;

public class DiesToLava : MonoBehaviour {

    //a spript for managing the characters reaction to terrains
    Rage_Bar rb;
    GameController gc;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
