using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
  // Gets the list of GameObjects that are entities 
  public List<GameObject> GetList() {
    List<GameObject> entityList = new List<GameObject>();
    Transform[] transformList = GetComponentsInChildren<Transform>(); 
    
    foreach (Transform childTransform in transformList) {
      GameObject childGameObject = childTransform.gameObject;

      // Tests if the GameObject is an entity
      if (childGameObject.GetComponent<EntityModel>() != null) {
        entityList.Add(childGameObject);
      }
    }

    return entityList;
  }
}
