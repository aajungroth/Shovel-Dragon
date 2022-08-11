using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour {
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

  // 
  public void CollisionDetection() {

  }

  // Stores ability and related information to be used in detecting collisions
  public void RegisterEvent(string ability, Vector2 direction,
  GameObject entity, Vector2 startPosition) {

  }

  // 
  protected void ResetLevel() {

  }
}
