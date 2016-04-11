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
