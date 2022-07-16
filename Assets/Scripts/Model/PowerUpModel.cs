using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModel : EntityModel {
  // The starting position of the power up
  public Vector2 initialPosition;

  // Tests if the power up has been buried
  public bool isBuried = true;

  // The name of the power up
  public string powerUpName;
}
