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
        Debug.Log("Ÿ�� �¾� �Ϸ�");
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

    //Ž�� ����
    private IEnumerator Search()
    {
        Debug.Log("Ÿ�� ���� : Search");
        while(true)
        {
            float nearest = float.MaxValue;

            //���ʹ� ����Ʈ���� ���� ���� ����� ���� ã�Ƽ� Ÿ������ ����
            for (int i = 0; i < enemySpawner.EnemyList.Count; i++)
            {
                float distance = Vector2.Distance(transform.position, enemySpawner.EnemyList[i].transform.position);

                if (nearest >= distance && attackRange >= distance)
                {
                    Debug.Log("Ÿ�� ���� �Ϸ�");
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
        Debug.Log("Ÿ�� ���� : Attack");
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

            //����
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
        // x, y�� ���� ���ϱ� (���� : ��ȭ��)
        //float displacementX = target.position.x - transform.position.x;
        //float displacementY = target.position.y - transform.position.y;

        Vector3 displacement = target.position - transform.position;

        //����
        float radian = Mathf.Atan2(displacement.y, displacement.x);

        //������ ��(����)�� �ٲ�� �Ѵ�.
        float degree = radian * Mathf.Rad2Deg;

        //ȸ���� ����
        transform.rotation = Quaternion.Euler(0, 0, degree); 
    }
}
