using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //�Ѹ��� �� �� ���� �� �¾����� (1�� ����)

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
