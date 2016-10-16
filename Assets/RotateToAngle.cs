using UnityEngine;
using System.Collections;

public class RotateToAngle : MonoBehaviour {

    public void setAngle(Quaternion a)
    {
        transform.rotation = new Quaternion(a.x, a.y, a.z, a.w);
    }
	void Update () {
	    
	}

}
