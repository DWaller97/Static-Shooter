﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedDamageButton : PurchaseableButton
{
    Weapon playerWeapon;

    public int[] newDamage;
    public TMPro.TextMeshProUGUI costText;

    private void Start()
    {
        playerWeapon = GameManager.GetInstance().player.weapon;
    }

    private void OnEnable()
    {
        UpdateCost();
    }

    public void UpdateCost()
    {
        if (timesPurchased >= maxPurchaseable)
            costText.text = "Max";
        else
            costText.text = prices[timesPurchased].ToString();
    }

    public void Buy()
    {
        if (timesPurchased < maxPurchaseable)
        {
            if (prices[timesPurchased] <= Scoring.score)
            {
                Scoring.score -= prices[timesPurchased];
                playerWeapon.damagePerShot = newDamage[timesPurchased];
                timesPurchased++;
                UpdateCost();
            }
        }
    }


}
