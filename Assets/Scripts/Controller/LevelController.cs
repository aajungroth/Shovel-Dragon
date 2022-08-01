using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  private string actionMoveDown = "move down";
  private string actionMoveLeft = "move left";
  private string actionMoveRight = "move right";
  private string actionMoveUp = "move up";

  // Handles requests to move the player down
  public void HandleMoveDown(Action done) {
    ExecuteTurn(done, Vector2.down, actionMoveDown);
  }

  // Handles requests to move the player left
  public void HandleMoveLeft(Action done) {
    ExecuteTurn(done, Vector2.left, actionMoveLeft);
  }

  // Handles requests to move the player right
  public void HandleMoveRight(Action done) {
    ExecuteTurn(done, Vector2.right, actionMoveRight);
  }

  // Handles requests to move the player up
  public void HandleMoveUp(Action done) {
    ExecuteTurn(done, Vector2.up, actionMoveUp);
  }

  // Determines if the player's attempted move will result in the
  // player moving to an empty space
  public void IsMoveValid(Vector2 move) {
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

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Action done, Vector2 move, string ability) {

  }
}
