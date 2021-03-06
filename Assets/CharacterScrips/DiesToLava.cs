﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class DiesToLava : MonoBehaviour {

    //a spript for managing the characters reaction to terrains
    Rage_Bar rb;
    GameController gc;
    private bool wasVulnerable;
    private bool amDead;
    private AudioSource source;
    public AudioClip death;
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        wasVulnerable = false;
        amDead = false;
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Lava" && Vulnerable())
        {
            if (!amDead)
            {
                GameObject go = Instantiate(Resources.Load("Prefabs/AnimatedFire") as GameObject);
                go.transform.position = gameObject.transform.position;
                go.GetComponent<SpriteRenderer>().sortingLayerName = "AbovePlayer";
                source.PlayOneShot(death);

            }
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
            if (!amDead)
            {
                GameObject go = Instantiate(Resources.Load("Prefabs/AnimatedFire") as GameObject);
                go.transform.position = gameObject.transform.position;
                go.GetComponent<SpriteRenderer>().sortingLayerName = "AbovePlayer";
                source.PlayOneShot(death);

            }
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
            Debug.Log(x);
            Collider2D overlaps = Physics2D.OverlapCircle(transform.position, 0.25f);
            if (overlaps.gameObject.tag == "Lava")//(x.GetComponent<PolygonCollider2D>().bounds.Contains(transform.position))
            {
                Debug.Log("Dying to Lava!");
                if (!amDead)
                {
                    GameObject go = Instantiate(Resources.Load("Prefabs/AnimatedFire") as GameObject);
                    go.transform.position = gameObject.transform.position;
                    go.GetComponent<SpriteRenderer>().sortingLayerName = "AbovePlayer";
                    source.PlayOneShot(death);
                }
                Die();
            }
        }
        wasVulnerable = Vulnerable();
        
    }
    
    public bool Die()
    {
        ///returns true if player dies.
        Debug.Log("I am dead!");
        
        gc.End(false);
        amDead = true;
        return true;
    }

    public bool Vulnerable()
    {
        ///returns true if player able to die
        return rb.vulnerable();
    }

}
