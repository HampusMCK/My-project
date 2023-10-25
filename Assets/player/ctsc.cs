using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ctsc : MonoBehaviour //Cash Text Script (ctsc)
{
    void Update()
    {
        GetComponent<TMP_Text>().text = $"${playerController.cash}";
    }
}
