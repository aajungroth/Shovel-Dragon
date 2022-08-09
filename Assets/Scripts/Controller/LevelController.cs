using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Manages all of the entity AIs for the track
  public EntityAIManager entityAIManager;

  // Controls the result of entities colliding
  public TrackController trackController;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(string ability, Action done, Vector2 playerDirection) {
    // The list of entities in the game
    List<GameObject> entityList = entityManager.GetList();

    // This action is called when an ability has finished rendering on the view
    Action completeAbility = GenerateCompleteAbility(done, entityList.Count);

    // The event generated by entity AI scripts
    EventModel entityEvent;

    // Loop through all of the entities in the game
    foreach (GameObject entity in entityList) {
      // Gets an event from the entity's AI script
      entityEvent = entityAIManager
        .GetEntityEvent(ability, entity, entityList, trackModel);

      // Registers the event with the track model 
      trackController.RegisterEvent(entityEvent);

      // Idling will not update the view
      if (entityEvent.direction == Vector2.zero) {
        completeAbility();
      }
      // Valid moves will be rendered on the view
      else if (ValidateMovement.IsMoveValid(entityEvent.direction, entity, trackModel)) {
        GridMovement.MoveTransformInDirection(completeAbility, entityEvent);
      }
      // Invalid moves will be rendered as an attempted move
      else {
        InvalidGridMovement.FeintTransformInDirection(completeAbility, entityEvent);
      }
    }
  }

  // Generates an action that will be run when the counter reaches
  // the total number of entites
  public Action GenerateCompleteAbility(Action done, int entityCount) {
    int completedCount = 0;

    // This action is called whenever an ability has been rendered by the view
    Action completeAbility = delegate() {
      // Increments the total number of completed abilities
      completedCount++;
      
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
    ExecuteTurn(AbilityModel.moveDown, done, Vector2.down);
  }

  // Handles requests to move the player left
  public void HandleMoveLeft(Action done) {
    ExecuteTurn(AbilityModel.moveLeft, done, Vector2.left);
  }

  // Handles requests to move the player right
  public void HandleMoveRight(Action done) {
    ExecuteTurn(AbilityModel.moveRight, done, Vector2.right);
  }

  // Handles requests to move the player up
  public void HandleMoveUp(Action done) {
    ExecuteTurn(AbilityModel.moveUp, done, Vector2.up);
  }
}
