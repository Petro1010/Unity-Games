using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FortuneFarmer
{
    public class SettingsUI : MonoBehaviour
    {
        // Start is called before the first frame update
        public void Start()
        {
            Debug.Log("Settings UI Loaded");
        }

        public void goBack()
        {
            GameController.instance.goBack();
        }
    }
}
