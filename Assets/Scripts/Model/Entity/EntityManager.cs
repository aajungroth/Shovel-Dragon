using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
  // The hole prefab used to instantiate new hole GameObjects
  public GameObject holePrefab;

  // A list of all GameObjects that are entities in the game
  private List<GameObject> entityList;

  // The GameObject that represents the player
  private GameObject player;

  // Awake is called before any other Start method
  void Awake() {
    entityList = GetChildren();
    player = FindPlayer(entityList);
  }

  // Creates a new hole GameObject entity under the EntityManager object's
  // GameObject and then adds it to the list
  public GameObject AddHole(Vector3 targetPosition, int initialLevel, 
  Vector2 initialPosition, char size) {
    // Creates a new hole GameObject at a requested position
    GameObject hole = Instantiate(holePrefab, targetPosition,
      Quaternion.identity);
    
    // Gets the hole model from the hole GameObject
    HoleModel holeModel = hole.GetComponent<HoleModel>();

    // Sets the hole's model data
    holeModel.initialLevel = initialLevel;
    holeModel.initialPosition = initialPosition;
    holeModel.Size = size;

    // Places the hole GameObject under the EntityManager GameObject
    hole.transform.parent = gameObject.transform;

    // Adds the hole GameObject to the list of entities
    entityList.Add(hole);

    return hole;
  }

  // Deletes an entity by index if it is a hole
  public void DeleteHole(int entityIndex) {
    // Gets a entity by index from the entity list
    GameObject entity = entityList[entityIndex];

    // Tests if the entity is a hole GameObject
    if (entity.GetComponent<HoleModel>() != null) {
      // Removes the hole GameObject from the entity list
      entityList.RemoveAt(entityIndex);

      // Deletes the hole GameObject
      entity.GetComponent<HoleModel>().fillHole();
    }
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
    // Creates a new of GameObjects for entities
    List<GameObject> entityList = new List<GameObject>();
    // Gets the list of transforms attached to the EntityManager's transform
    Transform[] transformList = GetComponentsInChildren<Transform>(); 

    // Searches through the list of transforms on the EntityManager's transform
    foreach (Transform childTransform in transformList) {
      // Gets the GameObject off of the transform
      GameObject childGameObject = childTransform.gameObject;

      // Tests if the GameObject is an entity
      if (childGameObject.GetComponent<EntityModel>() != null) {
        // Adds the entity to the list
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
