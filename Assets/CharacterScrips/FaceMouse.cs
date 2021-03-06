﻿using UnityEngine;
using System;

public class FaceMouse : MonoBehaviour {
	
    // a script that causes the attached object to rotate to face the mouse

	void LateUpdate () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print(transform.rotation.eulerAngles);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg - 90);
    }
    public void setAngle(Quaternion a)
    {
        transform.rotation = a;
    }
}
