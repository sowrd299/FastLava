using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

    GameObject go;
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

    public void spawnCorpse()
    {
        if (gameObject.name.Equals("Enemy(Clone)"))
        {
            go = Instantiate(Resources.Load("Prefabs/EnemyCorpse") as GameObject);
            go.transform.position = gameObject.transform.position;
            //go.GetComponent<RotateToAngle>().setAngle(transform.GetComponent<SpriteRenderer>().transform.rotation);
            //go.transform.rotation = transform.GetComponent<SpriteRenderer>().transform.rotation;
        }
        else if (gameObject.name.Equals("EnemyOne(Clone)"))
        {
            go = Instantiate(Resources.Load("Prefabs/EnemyOneCorpse") as GameObject);
            go.transform.position = gameObject.transform.position;
            //go.GetComponent<RotateToAngle>().setAngle(transform.GetComponent<SpriteRenderer>().transform.rotation);
            //go.transform.rotation = transform.GetComponent<SpriteRenderer>().transform.rotation;
        }
    }

    virtual public bool Die()
    {
        spawnCorpse();
        Destroy(gameObject);
        return true;
    }

}
