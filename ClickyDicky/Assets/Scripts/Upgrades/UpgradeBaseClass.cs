using UnityEngine;
using System.Collections;

namespace Game
{

    public class UpgradeBaseClass : MonoBehaviour
    {
        #region Variables
        [HideInInspector]
        public static UpgradeBaseClass instance = null;

        [Header("Money per click")]
        public float clickMultiplier = 1f;
        public float clickMultiplierCost = 50f;
        public int clickMultiplierLevel = 1;

        [Header("Critical click")]
        public float critClickProfit = 2f;
        public float critClickCost = 50f;
        public float[] critClickChance = { 0.01f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f };
        public int critClickLevel = 1;

        [Header("Gold bar event")]
        public float[] goldBarProfit = { 1000f, 5000f, 10000f };
        public float goldBarCost = 50f;
        public float goldBarChance = 0.05f;
        public float goldBarsPerMinute = 1f;
        public int goldBarLevel = 1;
        public float goldBarScreenTime = 10f;
        float _goldBarStepTime;

        [Header("Dependencies")]
        public GameObject critEffectObject;
        public GameObject goldBarObject;
        GameObject goldBarInstance;
        public GameObject goldBarSpawnPoint;
        public GameObject spawnPoint_Left;
        public GameObject spawnPoint_Right;
        #endregion

        #region Initialisation
        void Awake()
        {
            CheckInstance();

            _goldBarStepTime = goldBarsPerMinute * 60;
        }

        void CheckInstance()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void SetDefaults()
        {
            clickMultiplier = 1f;
        }
        #endregion

        #region Money per Click
        public void UpgradeClickMultiplier()
        {
            if (GameManager.manager.moneyInBank >= clickMultiplierCost)
            {
                clickMultiplierLevel += 1;
                clickMultiplier *= 2f;
                GameManager.manager.DecrementMoney(clickMultiplierCost);
                clickMultiplierCost *= 2;

                NyarLog.logger.Log("Upgraded Money Per Click to level " + clickMultiplierLevel);
            }
        }
        #endregion

        #region Critical Click
        public void UpgradeCriticalClick()
        {
            if (GameManager.manager.moneyInBank >= critClickCost && critClickLevel < critClickChance.Length)
            {
                critClickLevel += 1;

                GameManager.manager.DecrementMoney(critClickCost);
                critClickCost *= 2;

                NyarLog.logger.Log("Upgraded Critical Click Chance to level " + critClickLevel);
            }
        }

        public float CriticalClick()
        {
            if (Random.value <= critClickChance[critClickLevel - 1])
            {
                GameObject _critEffectInstance = (GameObject)Instantiate(critEffectObject, gameObject.transform.position, Quaternion.identity);
                Destroy(_critEffectInstance, 3f);
                return critClickProfit;
            }
            else
            {
                return 1f;
            }
        }
        #endregion

        #region Gold bar event
        public void UpgradeGoldBar()
        {
            if (GameManager.manager.moneyInBank >= goldBarCost && goldBarLevel < goldBarProfit.Length)
            {
                goldBarLevel += 1;

                GameManager.manager.DecrementMoney(goldBarCost);
                goldBarCost *= 2;

                NyarLog.logger.Log("Upgraded Critical Click Chance to level " + goldBarLevel);
            }
        }

        public void CheckIfGoldBarShouldSpawn()
        {
            if (Random.value <= goldBarChance && GameManager.manager.timeSinceGameStart >= _goldBarStepTime)
            {
                SpawnGoldBar();
            }
        }

        public void SpawnGoldBar()
        {
            Vector3 _originalPos = goldBarSpawnPoint.transform.position;

            RandomiseSpawnPoint();
            goldBarInstance = (GameObject)Instantiate(goldBarObject, goldBarSpawnPoint.transform.position, Quaternion.identity);
            StartCoroutine("MoveGoldBar");
            SetNewGoldBarStepTime();

            goldBarSpawnPoint.transform.position = _originalPos;
        }

        IEnumerator MoveGoldBar()
        {
            Vector3 _startPos = goldBarInstance.transform.position;
            Vector3 _endPos = goldBarInstance.transform.position + new Vector3(0, -22);

            float journeyLength = Vector3.Distance(_startPos, _endPos);
            float startTime = Time.time;

            float _speed = goldBarScreenTime / 10f;

            while (goldBarInstance.transform.position != _endPos)
            {
                float distCovered = (Time.time - startTime) * _speed;
                float fracJourney = distCovered / journeyLength;
                goldBarInstance.transform.position = Vector3.Lerp(_startPos, _endPos, fracJourney);

                yield return null;
            }

            Destroy(goldBarInstance);
        }

        void RandomiseSpawnPoint()
        {
            goldBarSpawnPoint.transform.position += new Vector3(-(Random.Range(spawnPoint_Left.transform.position.x, spawnPoint_Right.transform.position.x)), 0);
        }

        void SetNewGoldBarStepTime()
        {
            _goldBarStepTime += goldBarsPerMinute * 60f;
        }
        #endregion
    }
    //EOC
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