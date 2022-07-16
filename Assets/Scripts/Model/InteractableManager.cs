using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour {
  // Gets the list of GameObjects that are interactables 
  public List<GameObject> GetList() {
    List<GameObject> interactableList = new List<GameObject>();
    transform[] transformList = GetComponentsInChildren<transform>(); 
    
    foreach (transform childTransform in transformList) {
      GameObject childGameObject = childTransform.gameObject;

      // Tests if the GameObject is an interactable
      if (childGameObject.GetComponent<InteractableModel>() != null) {
        interactableList.Add(childGameObject);
      }
    }

    return interactableList;
  }
}
