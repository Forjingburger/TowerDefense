using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //체력을 구현하고, 피격 함수 구현

    [SerializeField] private float maxHp;
    private float currentHp;
    private float towerDamage;

    public float MaxHp { get { return maxHp; } }
    public float CurrentHp { get { return currentHp; } }

    private bool isDie = false;

    private Enemy enemy;
    private SpriteRenderer spriteRenderer;
    UpdateEnemyHP updateEnemyHP;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHp = maxHp;
    }

    public void EnemyHPSetup(UpdateEnemyHP tempEnemyHP)
    {
        updateEnemyHP = tempEnemyHP;
    }

    public void HitEnemy(float damage)
    {
        if (isDie) return;

        currentHp -= damage;

        updateEnemyHP.UpdateSliderValue();

        StartCoroutine(BlinkEnemy());
        if(currentHp <= 0)
        {
            isDie = true;
            enemy.DestroyEnemy(EnemyDeadType.Dead);
        }
    }    

    private IEnumerator BlinkEnemy()
    {
        Color temp = spriteRenderer.color;

        temp.a = 0.5f;
        spriteRenderer.color = temp;
        yield return new WaitForSeconds(0.2f);
        temp.a = 1;
        spriteRenderer.color = temp;
    }
}
