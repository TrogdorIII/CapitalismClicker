using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Variables

    [HideInInspector]
    public static GameManager manager;

    [Header("Game Info")]
    public float moneyInBank;
    public float moneyMadeAllTime;
    public int timesClickedAllTime;
    public float timeSinceGameStart;
    public float moneyPerSecond;
    public float moneyPerClick;
    public int goldBarsClicked;

    //Required Components
    

    #endregion

    #region Initialisation
    void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        // if the singleton hasn't been initialized yet
        if (manager != null && manager != this)
        {
            Destroy(this.gameObject);
        }

        manager = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    void Update()
    {
        UpdateData();
    }

    void UpdateData()
    {
        
    }

    public void ClickMoney()
    {
        IncrementMoney(moneyPerClick);
    }

    #region Setters

    public void IncrementMoney(float MoneyGain)
    {
        moneyInBank += Mathf.Abs(MoneyGain);
        moneyMadeAllTime += Mathf.Abs(MoneyGain);
    }

    public void DecrementMoney(float MoneyGain)
    {
        moneyInBank -= Mathf.Abs(MoneyGain);
    }

    public void IncrementClick(int click)
    {
        timesClickedAllTime = click;
    }

    public void SetMoneyPerClick(float amount)
    {
        moneyPerClick = amount; //ADD MODIFERS SHIT HERE
    }

    public void AdjustMoneyPerClick(float amount)
    {
        moneyPerClick += amount;
    }

    #endregion
}
