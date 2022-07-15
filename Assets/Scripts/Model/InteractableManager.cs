using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour {
  // Gets the list of the interactables 
  public List<Interactable> GetList() {
    List<Interactable> interactableList = new List<Interactable>();
    Interactable[] interactableComponentList = GetComponentsInChildren<Interactable>(); 
    
    foreach (Interactable interactableComponent in interactableComponentList) {
      interactableList.Add(interactableComponent);
    }

    return interactableList;
  }
}
