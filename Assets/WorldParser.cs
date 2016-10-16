using UnityEngine;

public class WorldParser : MonoBehaviour {

    private GameObject player;
    private GameObject[] spawnPoints;
    private GameObject[] spawnPointsOne;
    public int loadDistance;
    private bool Run
    {
        get
        {
            //allows for future optimizing
            return true;
        }
    }

	void Awake () {
        GameObject spawnPoint = GameObject.FindWithTag("PlayerStart");
        player = Instantiate(Resources.Load("Prefabs/Player") as GameObject);
        player.transform.position = spawnPoint.transform.position;
        spawnPoints = GameObject.FindGameObjectsWithTag("EnemyStart"); //runn too 
        spawnPointsOne = GameObject.FindGameObjectsWithTag("EnemyOneStart"); //run away
	}
	
	// Update is called once per frame
	void Update () {
        if (Run)
        {
            Spawn(spawnPoints, Resources.Load("Prefabs/Enemy") as GameObject); //spawn run-to's 
            Spawn(spawnPointsOne, Resources.Load("Prefabs/EnemyOne") as GameObject); //spawn run aways
        }
	}

    void Spawn(GameObject[] spawnPoints, GameObject prefab)
    {
        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            if (spawnPoints[i] && Vector2.Distance(spawnPoints[i].transform.position, player.transform.position) < loadDistance)
            {
                GameObject go = Instantiate(prefab);
                go.transform.position = spawnPoints[i].transform.position;
                spawnPoints[i] = null;
            }
        }

    }
}
