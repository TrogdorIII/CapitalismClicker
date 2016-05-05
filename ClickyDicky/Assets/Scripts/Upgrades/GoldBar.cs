using UnityEngine;
using System.Collections;

using Game;

public class GoldBar : MonoBehaviour {


    void OnMouseDown()
    {
        GameManager.manager.IncrementMoney(UpgradeBaseClass.instance.goldBarProfit[UpgradeBaseClass.instance.goldBarLevel - 1]);
        UpgradeBaseClass.instance.StopCoroutine("MoveGoldBar");
        Destroy(gameObject);
    }
}
