using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonHandler : MonoBehaviour
{
  [SerializeField]
  BuildingObjectBase item; Button button;

  private void Awake() 
  {
    button = GetComponent<Button>();
    button.onClick.AddListener(ButtonClicked);
  }

  private void ButtonClicked()
  {
    Debug.Log("Clicked!" + item.name);
  }
}
