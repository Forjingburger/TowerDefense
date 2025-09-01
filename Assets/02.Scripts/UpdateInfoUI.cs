using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHpText;

    public void UpdatePlayerHpText(float maxHp, float currentHp)
    {
        playerHpText.text = currentHp + " / " + maxHp;
    }
}
