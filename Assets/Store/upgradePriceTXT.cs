using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class upgradePriceTXT : MonoBehaviour
{
    void Update()
    {
        if (playerController.cash < bulletSc.upgradePrice)
        {
            GetComponent<TMP_Text>().color = Color.red;
        }
        else
        {
            GetComponent<TMP_Text>().color = Color.black;
        }
        GetComponent<TMP_Text>().text = $"Upgrade Gun:\n${bulletSc.upgradePrice}";
    }
}
