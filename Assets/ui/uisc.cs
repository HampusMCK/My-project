using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uisc : MonoBehaviour//Between Waves Ui Script
{
    [SerializeField]
    GameObject store, next; //UI Buttons

    void Update()
    {
        if (!playerController.wave) //If between waves: Show UI
        {
            store.SetActive(true);
            next.SetActive(true);
        }
        else if (playerController.wave) //If in wave: Hide UI
        {
            store.SetActive(false);
            next.SetActive(false);
        }
    }
}
