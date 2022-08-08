using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {
  // Determines if a monster's attempted move will result in
  // the monster moving to an empty space
  protected bool IsMoveValid(TrackModel trackModel, MonsterModel monster, Vector2 move) {
    List<IDictionary<string, bool>> track = trackModel.GetTrack();
    int currentLevel = 0;
    Vector2 targetPosition = Vector2.zero;
    string targetPositionKey = "";

    currentLevel = monster.GetCurrentLevel();
    targetPosition = monster.GetCurrentPosition() + move;
    targetPositionKey = targetPostion.x.ToString() + "," + targetPosition.y.ToString();

    return track[currentLevel][targetPositionKey];
  }
}
