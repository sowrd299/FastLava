using UnityEngine;

public class WorldParser : MonoBehaviour {

    private GameObject player;
    private GameObject[] spawnPoints;
    public int loadDistance;
    private bool Run
    {
        get
        {
            //allows for future optimizing
            return true;
        }
    }

	void Start () {
        GameObject spawnPoint = GameObject.FindWithTag("PlayerStart");
        player = Instantiate(Resources.Load("Prefabs/Player") as GameObject);
        player.transform.position = spawnPoint.transform.position;
        spawnPoints = GameObject.FindGameObjectsWithTag("EnemyStart");
	}
	
	// Update is called once per frame
	void Update () {
        if (Run)
        {
            for(int i = 0; i < spawnPoints.Length; ++i)
            {
                if (spawnPoints[i] && Vector2.Distance(spawnPoints[i].transform.position, player.transform.position) < loadDistance)
                {
                    GameObject go = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
                    go.transform.position = spawnPoints[i].transform.position;
                    spawnPoints[i] = null;
                }
            }
        }
	}
}
