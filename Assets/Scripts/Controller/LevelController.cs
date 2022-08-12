using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Manages all of the entity AIs for the track
  public EntityAIManager entityAIManager;

  // Handles rendering valid movement to the view
  public GridMovement gridMovement;

  // Handles rendering invalid movement attempts to the view
  public InvalidGridMovement invalidGridMovement;

  // Controls the result of entities colliding
  public TrackController trackController;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Action done, string playerAbility, Vector2 playerDirection) {
    // The list of entities in the game
    List<GameObject> entityList = entityManager.GetList();

    // This action is called when an ability has finished rendering on the view
    Action completeAbility = GenerateCompleteAbility(done, entityList.Count);

    // The level the player is currently on
    int currentLevel = trackModel.GetCurrentLevel();

    // The ability that the entities will perform
    string ability = AbilityModel.none;

    // The direction that the entities will move in
    Vector2 direction = Vector2.zero;

    // The position entities start the turn at
    Vector2 startPosition = Vector2.zero;

    // Loop through all of the entities in the game
    foreach (GameObject entity in entityList) {
      // Skips the entity if it is not in the current level
      if (entity.GetComponent<EntityModel>().GetCurrentLevel() != currentLevel) {
        continue;
      }

      // Gets the starting position of the entity
      startPosition = entity.GetComponent<EntityModel>().GetCurrentPosition();

      // Gets an event from the entity's AI script
      (ability, direction) = entityAIManager
        .GetEntityEvent(entity, entityList, playerAbility, playerDirection,
        trackModel);

      // Registers the event with the track model 
      trackController.RegisterAbility(ability, direction, entity, startPosition);

      // Idling will not update the view
      if (direction == Vector2.zero) {
        completeAbility();
      }
      // Valid moves will be rendered on the view
      else if (ValidateMovement.IsMoveValid(direction, entity, trackModel)) {
        // Update the entity model's current position
        // based on the movement ability
        if (ability == AbilityModel.moveDown) {
          entity.GetComponent<EntityModel>().MoveDown();
        }
        else if (ability == AbilityModel.moveLeft) {
          entity.GetComponent<EntityModel>().MoveLeft();
        }
        else if (ability == AbilityModel.moveRight) {
          entity.GetComponent<EntityModel>().MoveRight();
        }
        else if (ability == AbilityModel.moveUp) {
          entity.GetComponent<EntityModel>().MoveUp();
        }

        gridMovement.MoveTransformInDirection(direction, completeAbility, entity);
      }
      // Invalid moves will be rendered as an attempted move
      else {
        invalidGridMovement
          .FeintTransformInDirection(direction, completeAbility, entity);
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
    ExecuteTurn(done, AbilityModel.moveDown, Vector2.down);
  }

  // Handles requests to move the player left
  public void HandleMoveLeft(Action done) {
    ExecuteTurn(done, AbilityModel.moveLeft, Vector2.left);
  }

  // Handles requests to move the player right
  public void HandleMoveRight(Action done) {
    ExecuteTurn(done, AbilityModel.moveRight, Vector2.right);
  }

  // Handles requests to move the player up
  public void HandleMoveUp(Action done) {
    ExecuteTurn(done, AbilityModel.moveUp, Vector2.up);
  }
}
