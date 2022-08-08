using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Manages all of the monster AIs for the track
  public MonsterAIManager monsterAIManager;

  // Controls the result of entities colliding
  public TrackController trackController;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Action done, Vector2 move, string ability) {
    // The list of entities in the game
    List<GameObject> entityList = entityManager.GetList();

    // This action is called when an ability has finished rendering on the view
    Action<GameObject, string, string, Vector2, Vector2> completeAbility = 
      GenerateCompleteAbility(done, entityList.Count);

    // Loop through all of the entities in the game
    foreach (GameObject entity in entityList) {
      // Updates the entities by there AI
      monsterAIManager.GetEntityMove(entityList, trackModel, entity);
    }
  }

  // Generates an action that will be run when the counter
  // reaches the total number of entites
  public Action<GameObject, string, string, Vector2, Vector2> GenerateCompleteAbility(
  Action done, int entityCount) {
    int completedCount = 0;

    // This action is called by ExecuteTurn whenever an ability has been rendered by the view
    Action<GameObject, string, string, Vector2, Vector2> completeAbility = delegate(
    GameObject entity, string abilityType, string direction,
    Vector2 startPosition, Vector2 endPosition) {
      // Creates a new event that can be registered with the track controller
      EventModel eventModel = new EventModel();
      eventModel.abilityType = abilityType;
      eventModel.direction = direction;
      eventModel.endPosition = endPosition;
      eventModel.entity = entity;
      eventModel.startPosition = startPosition;

      // Increments the total number of completed abilities
      completedCount++;
      
      // Registers an event with the Track Controller
      trackController.RegisterEvent(eventModel);

      // Tests if the number of completed abilities matches
      // the number of entities
      if (completedCount == entityCount) {
        // Detects collisions based on the registered events
        trackController.CollisionDetection();
        // Runs code that is to executed once all events have been registered
        done();
      }
    };

    return completeAbility;
  }

  // Handles requests to move the player down
  public void HandleMoveDown(Action done) {
    ExecuteTurn(done, Vector2.down, AbilityModel.moveDown);
  }

  // Handles requests to move the player left
  public void HandleMoveLeft(Action done) {
    ExecuteTurn(done, Vector2.left, AbilityModel.moveLeft);
  }

  // Handles requests to move the player right
  public void HandleMoveRight(Action done) {
    ExecuteTurn(done, Vector2.right, AbilityModel.moveRight);
  }

  // Handles requests to move the player up
  public void HandleMoveUp(Action done) {
    ExecuteTurn(done, Vector2.up, AbilityModel.moveUp);
  }
}
