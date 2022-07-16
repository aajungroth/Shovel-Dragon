using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
  // A list of all GameObjects that are entities in the game
  private List<GameObject> entityList;

  // Awake is called before any other Start method
  void Awake() {
    entityList = GetChildren();
  }

  // Gets the list of entities
  public GetList() {
    return entityList;
  }

  // Gets the list of GameObjects that are entities 
  private List<GameObject> GetChildren() {
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
