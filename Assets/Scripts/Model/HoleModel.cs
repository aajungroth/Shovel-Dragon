using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleModel : EntityModel {
  // The starting position of the hole
  public Vector2 initialPosition;

  // The size of the hole which can be small (S), medium (M), or large (L)
  public char size;

  // Destroys the hole's GameObjects
  public fillHole() {
    Destroy(gameObject);
  }
}
