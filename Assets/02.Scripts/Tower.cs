using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerState
{
    Search,
    Attack
}


public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float attackSpeed = 0.5f;
    [SerializeField] private float attackRange = 2;

    [SerializeField] TowerState towerState;

    private Transform target;
    private EnemySpawner enemySpawner;
    private WaitForSeconds speed;

    public void Setup(EnemySpawner spawner)
    {
        Debug.Log("타워 셋업 완료");
        speed = new WaitForSeconds(attackSpeed);
        enemySpawner = spawner;

        ChangeState(TowerState.Search);
    }

    private void ChangeState(TowerState state)
    {
        StopCoroutine(towerState.ToString());
        towerState = state;
        StartCoroutine(towerState.ToString());
    }

    //탐색 상태
    private IEnumerator Search()
    {
        Debug.Log("타워 상태 : Search");
        while(true)
        {
            float nearest = float.MaxValue;

            //에너미 리스트에서 나와 가장 가까운 적을 찾아서 타겟으로 지정
            for (int i = 0; i < enemySpawner.EnemyList.Count; i++)
            {
                float distance = Vector2.Distance(transform.position, enemySpawner.EnemyList[i].transform.position);

                if (nearest >= distance && attackRange >= distance)
                {
                    Debug.Log("타겟 설정 완료");
                    nearest = distance;
                    target = enemySpawner.EnemyList[i].transform;
                }
            }
            if(target != null)
            {
                ChangeState(TowerState.Attack);
            }
            yield return null;
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("타워 상태 : Attack");
        while(true)
        {
            if(target == null)
            {
                ChangeState(TowerState.Search);
                break;
            }
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (attackRange < distance)
            {
                target = null;
                ChangeState(TowerState.Search);
                break;
            }
            yield return speed;

            //공격
            Fire();
        }
    }

    private void Fire()
    {
        Projectile projectile;
        GameObject projectileObj;
        projectileObj = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);

        projectile = projectileObj.GetComponent<Projectile>();
        if(target != null)
        {
            projectile.Setup(target.transform);
        }
    }

    private void Update()
    {
        if(target != null)
        {
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        // x, y의 변위 구하기 (변위 : 변화량)
        //float displacementX = target.position.x - transform.position.x;
        //float displacementY = target.position.y - transform.position.y;

        Vector3 displacement = target.position - transform.position;

        //라디안
        float radian = Mathf.Atan2(displacement.y, displacement.x);

        //라디안을 도(각도)로 바꿔야 한다.
        float degree = radian * Mathf.Rad2Deg;

        //회전에 적용
        transform.rotation = Quaternion.Euler(0, 0, degree); 
    }
}
