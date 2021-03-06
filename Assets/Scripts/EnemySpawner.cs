using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float secondsBetweenSpawns;
    float secondsSinceLastSpawn;

    public bool activated;


    private void Awake()
	{
        References.spawner = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        secondsSinceLastSpawn = 0;
    }

    // Fixed Updatehappens the same number of times for all players, so it's a good place for gameplay critical things.
    private void FixedUpdate()
    {
        if (activated)
		{
			SpawnEnemies();
		}
	}

	private void SpawnEnemies()
	{
		secondsSinceLastSpawn += Time.fixedDeltaTime;
		if (secondsSinceLastSpawn >= secondsBetweenSpawns)
		{
			Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
			secondsSinceLastSpawn = 0;
		}
	}
}
