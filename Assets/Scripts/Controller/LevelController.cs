using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
  // Manages all of the entities in the game
  public EntityManager entityManager;

  // A list of all GameObjects that are entities in the game
  private List<GameObject> entityList;

  // Start is called before the first frame update
  void Start() {
    // Get the entities as a list of GameObjects
    entityList = entityManager.GetList();
  }

  // Determines if the player's attempted move will result in the
  // player moving to an empty space
  public void IsMoveValid(Vector2 move) {

  }

  // Takes the player's move and updates game state accordingly
  public void ExecuteTurn(Vector2 move, string ability) {

  }
}
