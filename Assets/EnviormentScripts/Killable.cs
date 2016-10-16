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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.transform.position;
        Quaternion rotate = Quaternion.Euler(0, 0, Mathf.Atan2((transform.position.y- playerPos.y), (transform.position.x- playerPos.x )) * Mathf.Rad2Deg - 90);
        if (gameObject.name.Equals("Enemy(Clone)"))
        {
            go = Instantiate(Resources.Load("Prefabs/EnemyCorpse") as GameObject);
            go.transform.position = gameObject.transform.position;
            go.GetComponent<RotateToAngle>().setAngle(rotate);
            //go.transform.rotation = transform.GetComponent<SpriteRenderer>().transform.rotation;
        }
        else if (gameObject.name.Equals("EnemyOne(Clone)"))
        {
            go = Instantiate(Resources.Load("Prefabs/EnemyOneCorpse") as GameObject);
            go.transform.position = gameObject.transform.position;
            go.GetComponent<RotateToAngle>().setAngle(rotate);
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
