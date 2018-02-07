using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEnemyType{enemy1 = 0, enemy2 = 1, Random = 2 };

public class EnemySpawn : MonoBehaviour
{
    public float SpawnTime = 5;
    public float timer;
    public SpawnEnemyType Choose;
    public GameObject[] enemyTypes;

    void Awake ()
    {
        timer = SpawnTime;
	}
	
    void SpawnEnemy(SpawnEnemyType enemyType)
    {
        Vector3 pos = gameObject.transform.position;
        Quaternion rot = gameObject.transform.rotation;
        if (enemyType == SpawnEnemyType.Random)
        {
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], pos, rot);
        }
        else
        {
            Instantiate(enemyTypes[(int)enemyType], pos, rot);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
           
           SpawnEnemy(Choose);
           timer = SpawnTime;
           
        }

	}
}
