using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healButton : MonoBehaviour
{
    [SerializeField]
    Button b;

    // Update is called once per frame
    void Update()
    {
        if (playerController.cash < playerController.healPrice || playerController.health == 100)
        {
            b.interactable = false;
        }
        else
        {
            b.interactable = true;
        }
    }
}
