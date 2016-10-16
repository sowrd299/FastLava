using UnityEngine;
using System.Collections;

public class DrawRing : MonoBehaviour {

    // Use this for initialization
    public Texture blackRing;
    public Texture redRing;
    private float size;
    Rage_Bar rage;
    void Start () {

        size = 1;
        rage = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Rage_Bar>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 playerLocation = new Vector2(transform.position.x-size, transform.position.y-size);
        if (rage.vulnerable())
        {
            Graphics.DrawTexture(new Rect(playerLocation, new Vector2(2 * size, 2 * size)),blackRing);
        }
        else
        {
            Graphics.DrawTexture(new Rect(playerLocation, new Vector2(2 * size, 2 * size)), redRing);

        }


    }
}
