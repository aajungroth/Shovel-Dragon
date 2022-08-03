using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Ability names to be used to differentiate player abilities
  private string abilityMoveDown = "move down";
  private string abilityMoveLeft = "move left";
  private string abilityMoveRight = "move right";
  private string abilityMoveUp = "move up";

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

  // Detects collisions between entities each turn
  public void CollisionDetection() {

  }

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Action done, Vector2 move, string ability) {

  }
}
