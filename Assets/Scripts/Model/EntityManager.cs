using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
  // A list of all GameObjects that are entities in the game
  private List<GameObject> entityList;

  // The GameObject that represents the player
  private GameObject player;

  // Awake is called before any other Start method
  void Awake() {
    entityList = GetChildren();
    player = FindPlayer(entityList);
  }

  // Gets the list of entities
  public List<GameObject> GetList() {
    return entityList;
  }

  // Gets the player
  public GameObject GetPlayer() {
    return player;
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

  // Gets the player GameObjects from a list entity GameObjects
  private GameObject FindPlayer(List<GameObject> entityList) {
    GameObject player = new GameObject();

    foreach (GameObject entity in entityList) {
      // Tests if the GameObject is a player
      if (entity.GetComponent<PlayerModel>() != null) {
        player = entity;
        break;
      }
    }

    return player;
  }
}
