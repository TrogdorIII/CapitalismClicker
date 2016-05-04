﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class BuildingBaseClass
{

    public string name;
    public string description;
    public string tooltip;
    public float baseProfit;
    public float profit;
    public int cost;
    public int buildingsOwned = 0;
    public float upgradeLevel = 1f;

    public BuildingBaseClass(string name, string description, string tooltip, int cost, float baseProfit)
    {
        this.name = name;
        this.description = description;
        this.tooltip = tooltip;
        this.cost = cost;
        this.baseProfit = baseProfit;
    }

    public void BuyBuilding(int amount)
    {
        if (GameManager.manager.moneyInBank >= (cost * amount))
        {
            buildingsOwned += amount;
            GameManager.manager.DecrementMoney(cost * amount);
            cost *= 2;
            AdjustProfit();

            string _message = amount > 1 ? "Bought " + amount + " " + name + " buildings." : "Bought a " + name + " building.";
            NyarLog.logger.Log(_message);
        }
    }

    public void SellBuilding(int amount)
    {
        buildingsOwned -= amount;
        AdjustProfit();
    }

    public void UpgradeBuildingLevel()
    {
        upgradeLevel += 1;
        cost *= 2;
        AdjustProfit();

        NyarLog.logger.Log("Upgraded " + name + " to level " + upgradeLevel);
    }

    public void AdjustProfit()
    {
        profit = buildingsOwned * baseProfit * Mathf.Pow(2, upgradeLevel - 1);
    }
}

/*
 * profit = (b * bp) * 2^(u-1) ?
 * 
 * b = 3, bp = 1, u = 4:
 * profit = (3 * 1) * 2^(4-1)
 * = 3 * 8
 * = 24
 */