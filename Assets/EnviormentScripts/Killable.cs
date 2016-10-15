using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

    public int rageVal = 10; //public for unity; do not access
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
        Destroy(gameObject);
        return true;
    }

}
