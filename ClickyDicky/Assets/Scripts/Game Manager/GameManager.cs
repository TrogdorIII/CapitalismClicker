using UnityEngine;
using System.Collections;

using Game;
using UnityEngine.SceneManagement;

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
    float moneyGainInstance;
    public int goldBarsClicked;

    //Required Components
    

    #endregion

    #region Initialisation
    void Awake()
    {
        CreateInstance();

        timeSinceGameStart = 0;
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

        if (EndGameConditionsMet())
            EndGame();
    }

    void UpdateData()
    {
        timeSinceGameStart += Time.deltaTime;

        UpgradeBaseClass.instance.CheckIfGoldBarShouldSpawn();
    }

    public void ClickMoney()
    {
        moneyGainInstance = moneyPerClick * UpgradeBaseClass.instance.clickMultiplier * UpgradeBaseClass.instance.CriticalClick();
        IncrementMoney(moneyGainInstance);
        print(moneyGainInstance);
        
        timesClickedAllTime += 1;
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

    #region End Game
    public bool EndGameConditionsMet()
    {
        if (moneyInBank >= Mathf.Infinity)
            return true;

        return false;
    }

    public void EndGame()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        //Application.LoadLevel(Application.loadedLevel);
    }
    #endregion
}
