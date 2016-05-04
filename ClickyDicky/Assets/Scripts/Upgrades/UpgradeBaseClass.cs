using UnityEngine;
using System.Collections;

public class UpgradeBaseClass : MonoBehaviour {

    [Header("Money per click")]
    public float clickMultiplier = 1f;
    public float clickMultiplierCost = 50f;

    [Header("Critical click")]
    public float critClickProfit = 2f;
    public float[] clickCritChance = { 0.01f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f };
    public int critClickLevel = 1;

    [Header("Gold bar event")]
    public float[] goldBarProfit = { 1000f, 5000f, 10000f };
    public float goldBarChance = 0.05f;
    public float goldBarRatePerMinute = 1f;
    public int goldBarLevel = 1;
    public float goldBarScreenTime = 10f;

    [Header("Dependencies")]
    public GameObject critEffectObject;
    public GameObject goldBarOBject;

    #region Initialisation
    void Awake()
    {
        
    }

    public void SetDefaults()
    {
        clickMultiplier = 1f;
    }
    #endregion

    #region Money per Click
    
    #endregion

    #region Critical Click

    #endregion

    #region Gold bar event

    #endregion
}

/*
Upgrades/Buildings:

    Money per click upgrade - moneyPerClick *= 2; cost: cost *= 2;

    Money per second building

    Chance on click to crit (200%) - critChance = 1, 5, 10, 15, 20, 25

    Gold bar - 5% chance every min (have to click, falls down screen over 10s)- worth: 1000, 5000, 10000

Milestones:

    Changes sprite image at each threshold of an array

*/