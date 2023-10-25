using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    Button b;

    void Update()
    {
        if (playerController.cash < bulletSc.upgradePrice)
        {
            b.interactable = false;
        }
        else
        {
            b.interactable = true;
        }
    }
}
