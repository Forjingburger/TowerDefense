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
            //Debug.Log("���ʹ̿� �ε���");
            EnemyHP enemyHP = collision.gameObject.GetComponent<EnemyHP>();
            enemyHP.HitEnemy(damage);
            Destroy(gameObject);
        }

        //��ȹ ��� : ���θ��� ���ʹ̰� ��� �´� �� �ƴ϶� Ÿ�ٿ��� �Ѿ��� �������� �� ���
        //if (collision.transform != target) return;
    }
}
