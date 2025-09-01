using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float currentHp;

    UpdateInfoUI updateInfoUI;

    private void Awake()
    {
        currentHp = maxHp;
        updateInfoUI = GetComponent<UpdateInfoUI>();
        updateInfoUI.UpdatePlayerHpText(maxHp, currentHp);
    }

    public void UpdatePlayerHp(float damage)
    {
        currentHp -= damage;

        updateInfoUI.UpdatePlayerHpText(maxHp, currentHp);

        if(currentHp <= 0)
        {
            Debug.Log("게임오버!");
        }
    }
}
