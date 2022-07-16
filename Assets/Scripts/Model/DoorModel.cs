using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorModel : EntityModel {
  // The starting position of the door
  public Vector2 initialPosition;

  // Tests if door has been unlocked
  public bool isLocked = true;
}
