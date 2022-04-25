using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FortuneFarmer
{
    public class FarmUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI GameInfo;

        public FarmUI()
        {
            Debug.Log("Farm UI loaded");
        }

        public void UpdateFarmInfo(int coins, int time, string weather)
        {
            GameInfo.text = $"Coins: {coins}\nTime: {time}\nWeather: {weather}";
        }
    }
}
