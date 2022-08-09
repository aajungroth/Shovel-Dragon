using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModel : EntityModel {
  // Tests if the power up has been buried
  public bool isBuried = true;

  // Tests if the power up is following an entity
  public bool isFollowing = false;

  // The name of the power up
  public string powerUpName;
}
