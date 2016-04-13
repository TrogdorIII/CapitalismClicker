using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyCounterUI : MonoBehaviour
{

    public Text moneyImage;

    void Update()
    {
        moneyImage.text = GameManager.manager.moneyInBank.ToString();
    }
}
