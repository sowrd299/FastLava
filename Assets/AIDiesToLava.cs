using UnityEngine;
using System.Collections;

public class AIDiesToLava : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
        
    }
}
