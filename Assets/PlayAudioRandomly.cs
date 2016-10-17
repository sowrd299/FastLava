using UnityEngine;
using System.Collections;

public class PlayAudioRandomly : MonoBehaviour {

    // Use this for initialization
    float timer;
    float randomInterval;
    int randomSound;
    public AudioClip dashSwing;
    public AudioClip spinSwing;
    public AudioClip bootUp;
    public AudioClip whoosh;
    public AudioClip die;
    AudioClip[] clipList;
    private AudioSource source;
    void Start () {
        timer = 0;
        randomInterval = 1;
        randomSound = 0;
        clipList = new AudioClip[4];
        clipList[0] = dashSwing;
        clipList[1] = spinSwing;
        clipList[2] = bootUp;
        clipList[3] = whoosh;
        
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (timer > randomInterval)
        {
            randomInterval = (float)(Random.value * 2 + 2);
            timer = 0;
            randomSound = Random.Range(0, clipList.Length);
            source.PlayOneShot(clipList[randomSound]);
        } else
        {
            timer += Time.deltaTime;
        }

	}
}
