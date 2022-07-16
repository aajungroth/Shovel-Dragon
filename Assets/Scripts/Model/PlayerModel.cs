using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : EntityModel {
  // The direction the player is facing when the game starts
  public string intialDirection = "right";

  // The list of initial positions the player takes in each level
  public List<Vector2> initialPositionList;
}
