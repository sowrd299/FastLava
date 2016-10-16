﻿using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

    public int rageVal = 0; //public for unity; do not access
    virtual public int RageVal
    {
        get
        {
            return rageVal; 
        }
    }

    virtual public bool Hit()
    {
        ///To be called when hit by player durring dash.
        ///Returns true if killed.
        return Die();
    }

    virtual public void spawnCorpse()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/EnemyCorpse") as GameObject);
        go.transform.position = gameObject.transform.position;
    }
    
    virtual public bool Die()
    {
        spawnCorpse();
        Destroy(gameObject);
        return true;
    }

}
