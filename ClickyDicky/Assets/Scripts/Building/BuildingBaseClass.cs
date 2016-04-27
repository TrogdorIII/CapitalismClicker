using UnityEngine;
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
        AdjustProfit();
    }

    public void AdjustProfit()
    {
        //Get upgrade info HERE!!!!!!

        //Buildingsfuck
        profit = Mathf.Pow(buildingsOwned * baseProfit, upgradeLevel);
        //profit = buildingsOwned * baseProfit;
    }
}
