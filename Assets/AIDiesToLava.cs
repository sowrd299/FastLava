using UnityEngine;
using System.Collections;

public class AIDiesToLava : MonoBehaviour {

    private GameObject go;

    // Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Lava")
        {
            go = Instantiate(Resources.Load("Prefabs/AnimatedFire") as GameObject);
            go.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        
    }
}
