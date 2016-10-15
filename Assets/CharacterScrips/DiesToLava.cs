using UnityEngine;
using System.Collections;

public class DiesToLava : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Lava")
        {
            Die();
        }
    }

    public bool Die()
    {
        Debug.Log("I am dead!");
        return true;
    }

}
