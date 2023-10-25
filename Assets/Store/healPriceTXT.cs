using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healPriceTXT : MonoBehaviour
{
    void Update()
    {
         if (playerController.cash < playerController.healPrice)
        {
            GetComponent<TMP_Text>().color = Color.red;
        }
        else
        {
            GetComponent<TMP_Text>().color = Color.black;
        }
        GetComponent<TMP_Text>().text = $"Heal:\n${playerController.healPrice}";
    }
}
