using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //한마리 씩 적 생성 후 셋업까지 (1초 간격)

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] wayPoints;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        //for(int i = 0; i <= wayPoints.Length; i++)
        //{
        //    Debug.Log(wayPoints[i]);
        //}

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemyPrefab);
            enemy.Setup(wayPoints);

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
}
