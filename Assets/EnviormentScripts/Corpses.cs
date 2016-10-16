using UnityEngine;
using System.Collections;

public class Corpses : MonoBehaviour {

    Camera cam;

    void Start()
    {
        GameObject tempObject = GameObject.FindGameObjectWithTag("MainCamera");
        cam = tempObject.GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);
        if (!(screenPos.x < 1 && screenPos.x > 0 && screenPos.y < 1 && screenPos.y > 0))
        {
            Destroy(gameObject);
        }
    }

}