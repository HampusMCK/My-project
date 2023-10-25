using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class upgradePriceTXT : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().text = $"Upgrade Gun:\n${bulletSc.upgradePrice}";
    }
}
