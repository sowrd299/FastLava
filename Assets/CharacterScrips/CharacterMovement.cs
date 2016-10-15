using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float playerSpeed = 10f;
    public float dashCooldown;
    private float cooldownTimer;
    Rage_Bar rage;
    private float dashDistance;

	// Use this for initialization
	void Start () {
        
        dashDistance = 0;
        cooldownTimer = 0;
        
        rage = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
        print(rage.GetType());

    }

	// Update is called once per frame
	void Update () {
        dashDistance = (float)(0.07 * rage.GetRage() + 0.5);
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
        //print(dashCooldown);
        if(cooldownTimer > 0)
        {
            cooldownTimer-= Time.deltaTime;
        } else
        {
            if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            {
                cooldownTimer = dashCooldown;
                GetComponent<Dash>().dash(dashDistance, 1);
               
            }
        }
        
	}
}
