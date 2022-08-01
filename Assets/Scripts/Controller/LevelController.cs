using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // Stores the layout of each level in the track
  public TrackModel trackModel;

  // Determines if the player's attempted move will result in the
  // player moving to an empty space
  public void IsMoveValid(Vector2 move) {

  }

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Vector2 move, string ability) {

  }
}
