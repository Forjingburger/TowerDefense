using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private GameObject enemyGroup;

    [SerializeField] private GameObject enemyHpBarPrefab;
    [SerializeField] private Transform canvas;

    //자동 구현 프로퍼티 => 변수 안 만들어도 된다.
    public List<Enemy> EnemyList { get; set; }

    private PlayerHP playerHp;

    private void Start()
    {
        EnemyList = new List<Enemy>();
        playerHp = GetComponent<PlayerHP>();

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

            CreateEnemyHpBar(enemyObject);

            yield return new WaitForSeconds(1f);
        }
    }

    private void CreateEnemyHpBar(GameObject enemy)
    {
        GameObject enemyHpBar = Instantiate(enemyHpBarPrefab, canvas);

        enemyHpBar.GetComponent<UpdateEmemyHPBarPosition>().Setup(enemy.transform);
        enemyHpBar.GetComponent<UpdateEnemyHP>().Setup(enemy.GetComponent<EnemyHP>());
    }

    public void EnemyDestory(Enemy enemy, EnemyDeadType type)
    {
        if(type == EnemyDeadType.Finish)
        {
            playerHp.UpdatePlayerHp(1);
        }

        EnemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
