using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAIManager : MonoBehaviour {
  // Stores the Entity AI scripts by an AI name
  protected IDictionary<string, EntityAI> entityAIByName =
    new Dictionary<string, EntityAI>();

  // Calls the Entity AI script to get the AI's next move
  public EventModel GetEntityEvent(GameObject entity,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    // Gets the name of the AI that the entity is using
    string AIName = entity.GetComponent<EntityModel>().AIName;

    // Creates a new event that can be registered with the track controller
    EventModel entityEvent = transform.gameObject.AddComponent<EventModel>();
    entityEvent.startPosition = entity
      .GetComponent<EntityModel>()
      .GetCurrentPosition();

    // Makes sure that the requested entity AI exists
    if (entityAIByName.ContainsKey(AIName)) {
      // Gets the entity AI script by name from the dictionary and calls
      // the GetMove method to get the next position to move to
      entityEvent = entityAIByName[AIName]
        .GetEvent(entity, entityEvent, entityList, playerAbility,
        playerDirection, trackModel);
    }

    return entityEvent;
  }
}
