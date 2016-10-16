using UnityEngine;
using System.Collections;

public class BulletSpin : MonoBehaviour {

    // Use this for initialization
    private float theta;
    public float spinSpeed;
	void Start () {
        theta = 0;
       
	}
	
	// Update is called once per frame
	void Update () {
        theta += spinSpeed;
        transform.Rotate(Vector3.forward*Time.deltaTime * theta);
	}
}
