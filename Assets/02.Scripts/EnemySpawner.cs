using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] wayPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        GameObject enemyObject;
        Enemy enemy;

        while (true)
        {
            enemyObject = Instantiate(enemyPrefab);
            enemy = enemyObject.GetComponent<Enemy>();
            enemy.Setup(wayPoints);

            yield return new WaitForSeconds(1f);
        }
    }
}
