using UnityEngine;
using System.Collections;

namespace Game
{

    public class BuildingHolder : MonoBehaviour
    {
        #region Variables
        [HideInInspector]
        public static BuildingHolder instance = null;

        public BuildingBaseClass[] buildings;
        private float timer;
        #endregion

        void Awake()
        {
            CheckInstance();
        }

        void CheckInstance()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (timer > 1)
            {
                CalculateBuildingProfit();
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        public void CalculateBuildingProfit()
        {
            foreach (var building in buildings)
            {
                GameManager.manager.IncrementMoney(building.profit);
            }
        }

        #region BuyBuilding
        public void BuyOneBuilding(string name)
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].name == name)
                {
                    buildings[i].BuyBuilding(1);
                }
            }
        }

        public void UpgradeBuilding(string name)
        {
            foreach (BuildingBaseClass building in buildings)
            {
                if (building.name == name)
                {
                    building.UpgradeBuildingLevel();
                }
            }
        }

        public void UpgradeAll()
        {
            foreach (BuildingBaseClass building in buildings)
            {
                building.UpgradeBuildingLevel();
            }
        }
        #endregion
    }
    //EOC
}