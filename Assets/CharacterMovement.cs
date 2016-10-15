using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float playerSpeed = 10;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement() {
		float translation = Time.deltaTime * playerSpeed;

		if (Input.GetKey("w"))
			transform.Translate(0, translation, 0);
		if (Input.GetKey("a"))
			transform.Translate(-translation, 0, 0);
		if (Input.GetKey("s"))
			transform.Translate(0, -translation, 0);
		if (Input.GetKey("d"))
			transform.Translate(translation, 0, 0);
	}
}
