using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnemyHP : MonoBehaviour
{
    private EnemyHP enemyHp;
    private Slider slider;

    public void Setup(EnemyHP hp)
    {
        enemyHp = hp;
        enemyHp.EnemyHPSetup(this);

        slider = GetComponent<Slider>();

        slider.value = 1;
    }    

    public void UpdateSliderValue()
    {
        slider.value = enemyHp.CurrentHp / enemyHp.MaxHp;
    }  
}
