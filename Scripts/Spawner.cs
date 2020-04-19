using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
	float randX;
	Vector2 whereToSpawn;
	public float spawnRate;
	float nextSpawn = 0.0f;




	void Start()
    {
		
    }

	void Update()
    {
		

		if (Time.time > nextSpawn)
        {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-3.51f, 8.15f);
			whereToSpawn = new Vector2(randX, transform.position.y);
			Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }




	
}