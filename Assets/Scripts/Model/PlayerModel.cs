using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : EntityModel {
  // The public property for the private currentDirection variable
  public string CurrentDirection {
    get {
      return currentDirection;
    }
    set {
      currentDirection = value;
    }
  }

  // The direction the player is facing when the game starts
  public string initialDirection = "right";

  // The list of initial positions the player takes in each level
  public List<Vector2> initialPositionList;

  // The direction the player is currently facing
  private string currentDirection;

  // Awake is called before any other Start method
  void Awake() {
    currentDirection = initialDirection;
  }
}
