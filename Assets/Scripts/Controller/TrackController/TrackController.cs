using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TrackController : MonoBehaviour {
  // The list of entities that performed abilities during the turn
  private List<GameObject> entityList = new List<GameObject>();

  // The abilities that were performed by entities during the turn
  private IDictionary<GameObject, string> abilityByEntity =
    new Dictionary<GameObject, string>();

  // The directions each entity peformed their abilitiy in during the turn
  private IDictionary<GameObject, Vector2> directionByEntity =
    new Dictionary<GameObject, Vector2>();

  // The positions the entities started the turn in
  private IDictionary<GameObject, Vector2> startPositionByEntity =
    new Dictionary<GameObject, Vector2>();

  // The positions the entities ended the turn in
  private IDictionary<Vector2, List<GameObject>> entityListByEndPosition =
    new Dictionary<Vector2, List<GameObject>>();

  // Handles garbage collection when collision detection has finished
  private void ClearData() {
    entityList = new List<GameObject>();
    abilityByEntity = new Dictionary<GameObject, string>();
    directionByEntity = new Dictionary<GameObject, Vector2>();
    startPositionByEntity = new Dictionary<GameObject, Vector2>();
    entityListByEndPosition = new Dictionary<Vector2, List<GameObject>>();
  }

  // Determines which entities passed through each other or
  // landded on the same space during the turn
  public void CollisionDetection() {
    string ability = "";
    List<GameObject> colliderEntityList;
    Vector2 direction = Vector2.zero;
    Vector2 endPosition = Vector2.zero;
    Vector2 startPosition = Vector2.zero; 

    // Checks each entity to see what it collides with
    foreach (GameObject entity in entityList) {
      ability = abilityByEntity[entity];
      direction = directionByEntity[entity];
      startPosition = startPositionByEntity[entity];

      if (ability.Split(' ')[0] == AbilityModel.moveDown.Split(' ')[0]) {
        endPosition = startPosition + direction;
        colliderEntityList = entityListByEndPosition[endPosition];

        foreach (GameObject colliderEntity in colliderEntityList) {
          if (entity.GetComponent<PlayerModel>() != null &&
          colliderEntity.GetComponent<DoorModel>() != null) {
            resolveDoorPlayerCollision(colliderEntity, entity);
          }
          else if(entity.GetComponent<DoorModel>() != null &&
          colliderEntity.GetComponent<PlayerModel>() != null) {
            resolveDoorPlayerCollision(entity, colliderEntity);
          }
        }
      }
    }
  }

  // Stores ability and related information to be used in detecting collisions
  public void RegisterAbility(string ability, Vector2 direction,
  GameObject entity, Vector2 startPosition) {
    // The position the entity will be at by the end of the turn
    Vector2 endPosition = startPosition + direction;

    // The list of entites at a given end position
    List<GameObject> overlappingEntityList;

    // Store the relevant information for collision detection
    entityList.Add(entity);
    abilityByEntity.Add(entity, ability);
    directionByEntity.Add(entity, direction);
    startPositionByEntity.Add(entity, startPosition);

    // Adds the entity by the end position to an existing entity list
    if (entityListByEndPosition.ContainsKey(endPosition)) {
      overlappingEntityList = entityListByEndPosition[endPosition];
      overlappingEntityList.Add(entity);
    }
    // Creates a new entity list to add the entity list to by end position
    else {
      overlappingEntityList = new List<GameObject>();
      overlappingEntityList.Add(entity);
      entityListByEndPosition.Add(endPosition, overlappingEntityList);
    }
  }

  // 
  protected void ResetLevel() {

  }

  // Collision resolution methods to be overrided
  // in derived classes for specific tracks
  abstract protected void resolveDoorPlayerCollision(GameObject door, GameObject player);
}
