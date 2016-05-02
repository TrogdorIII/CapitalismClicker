using UnityEngine;
using System.Collections;

public class UpgradeBaseClass : MonoBehaviour {

    public float clickMultiplier = 1f;

    #region Initialisation
    void Awake()
    {
        
    }

    public void SetDefaults()
    {
        clickMultiplier = 1f;
    }
    #endregion

    #region Upgrade Methods
    public void AdjustValue(int value)
    {
        
    }
    #endregion
}

/*
Upgrades/Buildings:

    Money per click upgrade - moneyPerClick *= 2; cost: cost *= 2;

    Money per second building

    Chance on click to crit (250%) - critChance = 1, 5, 10, 15, 20, 25

    Gold bar - 5% chance every min (have to click, falls down screen over 10s)- worth: 1000, 5000, 10000

Milestones:

    Changes sprite image at each threshold of an array

*/