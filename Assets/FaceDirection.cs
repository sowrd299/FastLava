using UnityEngine;
using System.Collections;

public class FaceDirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(GetComponentInParent<BulletMovement>().getDirection() * Mathf.Rad2Deg, Vector3.back);
    }
    
}
