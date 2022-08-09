using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAIManager : MonoBehaviour {
  // Stores the Entity AI scripts by an AI name
  protected IDictionary<string, EntityAI> entityAIByName;

  // Calls the Entity AI script to get the AI's next move
  public EventModel GetEntityEvent(string ability, GameObject entity,
  List<GameObject> entityList, TrackModel trackModel) {
    string AIName = entity.GetComponent<EntityModel>().AIName;
    Vector2 currentPosition = entity.GetCurrentPosition();
    Vector2 direction = Vector2.zero;

    // Makes sure that the requested entity AI exists
    if (entityAIByName.ContainsKey(AIName)) {
      // Gets the entity AI script by name from the dictionary and calls
      // the GetMove method to get the next position to move to
      direction = entityAIByName[AIName]
        .GetDirection(ability, entity, entityList, trackModel);
    }

    // Creates a new event that can be registered with the track controller
    EventModel entityEvent = new EventModel();
    entityEvent.ability = ability;
    entityEvent.direction = direction;
    entityEvent.endPosition = currentPosition + direction;
    entityEvent.entity = entity;
    entityEvent.startPosition = currentPosition;

    return entityEvent;
  }
}
