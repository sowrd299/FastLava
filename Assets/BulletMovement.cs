using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    // Use this for initialization

    private float direction;
    private float speed;
    private Vector3 moveVector;
    Camera cam;
	void Start () {

        GameObject tempObject = GameObject.FindGameObjectWithTag("MainCamera");
        cam = tempObject.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update() {
        moveVector = calculateMoveVector();
        transform.Translate(moveVector * Time.deltaTime );
        
        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        if(!(screenPos.x < 1 && screenPos.x >0 && screenPos.y < 1 && screenPos.y > 0))
        {
            Destroy(gameObject);   
        }
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Destroy(gameObject);

    }
    public void setDirection(float x)
    {
        direction = x;
    }
    public float getDirection()
    {
        return direction;
    }
    public void setSpeed(float x)
    {
        speed = x;
    }
    public Vector3 calculateMoveVector()
    {
        moveVector = new Vector3(speed * Mathf.Cos(direction), speed * Mathf.Sin(direction),0);
        return moveVector;
    }

}
