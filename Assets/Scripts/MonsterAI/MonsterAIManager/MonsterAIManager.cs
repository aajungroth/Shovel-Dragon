using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIManager : MonoBehaviour {
  // Stores the Monster AI scripts by an AI name
  protected IDictionary<string, MonsterAI> monsterAIByName;

  // Calls the Monster AI script to get the AI's next move
  public Vector2 GetMonsterMove(List<EntityModel> entityList,
  TrackModel trackModel, MonsterModel monster, string monsterAIName) {
    Vector2 move = Vector2.zero;

    // Makes sure that the requested monster AI exists
    if (monsterAIByName.ContainsKey(monsterAIName)) {
      // Gets the monster AI script by name from the dictionary and calls
      // the GetMove method to get the next position to move to
      move = monsterAIByName[monsterAIName]
        .GetMove(entityList, trackModel, monster);
    }

    return move;
  }
}
