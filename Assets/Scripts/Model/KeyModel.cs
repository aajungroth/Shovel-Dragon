using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyModel : EntityModel {
  // The starting position of the key
  public Vector2 initialPosition;

  // Tests if the key has been buried
  public bool isBuried = false;
}
