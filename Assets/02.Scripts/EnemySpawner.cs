using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private GameObject enemyGroup;

    //자동 구현 프로퍼티 => 변수 안 만들어도 된다.
    public List<Enemy> EnemyList { get; set; }

    private void Start()
    {
        EnemyList = new List<Enemy>();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        GameObject enemyObject;
        Enemy enemy;

        while (true)
        {
            enemyObject = Instantiate(enemyPrefab, enemyGroup.transform);
            enemy = enemyObject.GetComponent<Enemy>();

            enemy.Setup(wayPoints, this);
            EnemyList.Add(enemy);

            yield return new WaitForSeconds(1f);
        }
    }

    public void EnemyDestory(Enemy enemy)
    {
        EnemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
