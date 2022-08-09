using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAIManager : EntityAIManager {
  // The AI scripts used for the track
  public FixedMovementAI fixedMovementAI;
  public PlayerAI playerAI;

  // The names of the AI scripts used for the dictionary keys
  public string fixedMovementAIName = "fixed movement";
  public string playerAIName = "player";

  // Awake is called before any other Start method
  void Awake() {
    // Add the AI scripts to the dictionary by name
    entityAIByName.Add(fixedMovementAIName, fixedMovementAI);
    entityAIByName.Add(playerAIName, playerAI);
  }
}
