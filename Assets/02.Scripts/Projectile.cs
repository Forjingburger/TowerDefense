using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement movement;
    private Transform target;

    public void Setup(Transform enemy)
    {
        movement = GetComponent<Movement>();
        target = enemy;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            movement.MoveDirection = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("¿¡³Ê¹Ì¿¡ ºÎµúÈû");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
