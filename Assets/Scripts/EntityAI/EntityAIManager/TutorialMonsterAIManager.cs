using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMonsterAIManager : MonsterAIManager {
  // The AI script used for the track
  public FixedMovementAI fixedMovementAI;

  // The name of the AI scripts used for the dictionary key
  public string fixedMovementAIName = "fixed movement";

  // Awake is called before any other Start method
  void Awake() {
    // Add the AI script to the dictionary by name
    monsterAIByName.Add(fixedMovementAIName, fixedMovementAI);
  }
}
