using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAIManager : MonoBehaviour {
  // Stores the Entity AI scripts by an AI name
  protected IDictionary<string, EntityAI> entityAIByName;

  // Calls the Entity AI script to get the AI's next move
  public EventModel GetEntityEvent(string ability, EntityModel entity,
  List<GameObject> entityList, TrackModel trackModel) {
    Vector2 currentPosition = entity.GetCurrentPosition();
    Vector2 direction = Vector2.zero;

    // Makes sure that the requested entity AI exists
    if (entityAIByName.ContainsKey(entity.AIName)) {
      // Gets the entity AI script by name from the dictionary and calls
      // the GetMove method to get the next position to move to
      direction = entityAIByName[entity.AIName]
        .GetDirection(ability, entity, entityList, trackModel);
    }

    // Creates a new event that can be registered with the track controller
    EventModel entityEvent = new EventModel();
    eventModel.ability = ability;
    eventModel.direction = direction;
    eventModel.endPosition = currentPosition + direction;
    eventModel.entity = entity;
    eventModel.startPosition = currentPosition;

    return entityEvent;
  }
}
