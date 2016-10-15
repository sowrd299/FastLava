using UnityEngine;
using System.Collections;

public class DiesToLava : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("I'm touching something!");
        if(c.gameObject.tag == "Lava")
        {
            Debug.Log("I'm dying!");
        }
    }

}
