using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public static GameManager manager;

    [Header("Money Info")]
    public float moneyAvaliable;

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

}
