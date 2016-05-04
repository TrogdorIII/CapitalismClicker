using UnityEngine;
using System.Collections;

namespace Game
{

    public class BuildingHolder : MonoBehaviour
    {

        public BuildingBaseClass[] buildings;
        private float timer;

        void Update()
        {
            if (timer > 1)
            {
                CalculateBuildingProfit();
                timer = 0;
            }
            timer += Time.deltaTime;

            //TEST INPUT
            if (Input.GetKeyDown("1"))
                UpgradeBuilding("bongo");
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
        #endregion
    }

}