using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement movement;
    private Transform target;

    private float damage;


    public void Setup(Transform enemy, float towerDamage)
    {
        movement = GetComponent<Movement>();
        target = enemy;
        damage = towerDamage;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            movement.MoveDirection = direction;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //Debug.Log("에너미에 부딪힘");
            EnemyHP enemyHP = collision.gameObject.GetComponent<EnemyHP>();
            enemyHP.HitEnemy(damage);
            Destroy(gameObject);
        }

        //기획 요소 : 가로막는 에너미가 대신 맞는 게 아니라 타겟에게 총알이 박히도록 할 경우
        //if (collision.transform != target) return;
    }
}
