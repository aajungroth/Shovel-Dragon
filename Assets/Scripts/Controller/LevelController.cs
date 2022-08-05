using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Controls the result of entities colliding
  public TrackController trackController;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Ability names to be used to differentiate player abilities
  private string abilityMoveDown = "move down";
  private string abilityMoveLeft = "move left";
  private string abilityMoveRight = "move right";
  private string abilityMoveUp = "move up";

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Action done, Vector2 move, string ability) {

  }

  // Generates an action that will be run when the counter
  // reaches the total number of entites
  public Action<GameObject, string, string, Vector2, Vector2> GenerateCompleteAbility(
  Action done, int entityCount) {
    // todo add dictionary to track data
    int completedCount = 0;

    Action<GameObject, string, string, Vector2, Vector2> completeAbility = delegate(
    GameObject entity, string abilityType, string direction,
    Vector2 startPosition, Vector2 endPosition) {
      completedCount++;
      // todo add data to the dictionary

      if (completedCount == entityCount) {
        // todo update to take dictionary as argument
        CollisionDetection();
        // todo run update on track controller
        done();
      }
    };

    return completeAbility;
  }

  // Handles requests to move the player down
  public void HandleMoveDown(Action done) {
    ExecuteTurn(done, Vector2.down, abilityMoveDown);
  }

  // Handles requests to move the player left
  public void HandleMoveLeft(Action done) {
    ExecuteTurn(done, Vector2.left, abilityMoveLeft);
  }

  // Handles requests to move the player right
  public void HandleMoveRight(Action done) {
    ExecuteTurn(done, Vector2.right, abilityMoveRight);
  }

  // Handles requests to move the player up
  public void HandleMoveUp(Action done) {
    ExecuteTurn(done, Vector2.up, abilityMoveUp);
  }

  // Determines if the player's attempted move will result in the
  // player moving to an empty space
  public bool IsMoveValid(Vector2 move) {
    List<IDictionary<string, bool>> track = trackModel.GetTrack();
    GameObject player = entityManager.GetPlayer();
    int currentLevel = 0;
    Vector2 targetPosition = Vector2.zero;
    string targetPositionKey = "";

    currentLevel = player.GetComponent<PlayerModel>().GetCurrentLevel();
    targetPosition = player.GetComponent<PlayerModel>().GetCurrentPosition() + move;
    targetPositionKey = targetPosition.x.ToString() + "," + targetPosition.y.ToString();

    return track[currentLevel][targetPositionKey];
  }
}
