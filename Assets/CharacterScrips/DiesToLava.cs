using UnityEngine;
using UnityEngine.SceneManagement;

public class DiesToLava : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Lava" && Vulnerable())
        {
            Die();
        }
    }

    public bool Die()
    {
        ///returns true if player dies.
        Debug.Log("I am dead!");
        return true;
    }

    public bool Vulnerable()
    {
        ///returns true if player able to die
        SceneManager.LoadScene("GameOver");
        return true;
    }

}
