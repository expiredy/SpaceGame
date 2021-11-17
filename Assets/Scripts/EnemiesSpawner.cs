using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    public GameObject[] enemiesPrefabList;
    private float enemyDefaultPadding = 1f;

    private float enemySpawningCooldown = 0.5f;
    
    private float spawningBoardWidth, spawningBoardHeight;
    private bool isReadyForSpawnEnemy = true;
    
    void Awake()
    {
        spawningBoardWidth = Camera.main.orthographicSize;
        spawningBoardHeight = spawningBoardWidth * Camera.main.aspect;
    }

    // Update is called once per frame3
    void Update()
    {
        if (isReadyForSpawnEnemy)
        {
            this.SpawnEnemy();
        }
    }

    IEnumerator EnemySpawnCooldownReloading()
    {
        yield return new WaitForSeconds(enemySpawningCooldown);
        isReadyForSpawnEnemy = true;
    }
    
    private void SpawnEnemy()
    {
        int enemiesTypeIndex = Random.Range(0, this.enemiesPrefabList.Length);
        GameObject spawnedEnemy = Instantiate(this.enemiesPrefabList[enemiesTypeIndex]);
        float enemyPadding = enemyDefaultPadding;
        if (spawnedEnemy.GetComponent<Enemy>() != null)
        {
            enemyPadding = spawnedEnemy.GetComponent<Enemy>().radius;
        }

        Vector3 newPosition = Vector3.zero;
        float xCordMax = spawningBoardWidth + enemyPadding;
        float xCordMin = -spawningBoardWidth - enemyPadding;
        newPosition.x = Random.Range(xCordMin, xCordMax);
        newPosition.y = spawningBoardHeight + enemyPadding;
        spawnedEnemy.transform.position = newPosition;
        isReadyForSpawnEnemy = false;
        StartCoroutine("EnemySpawnCooldownReloading");
    }
        
}
