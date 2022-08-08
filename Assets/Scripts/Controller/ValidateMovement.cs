using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValidateMovement : MonoBehaviour {
  // Determines if the entity's attempted move will result in the
  // entity moving to an empty space
  public static bool IsMoveValid(EntityModel entity, TrackModel trackModel, Vector2 move) {
    List<IDictionary<string, bool>> track = trackModel.GetTrack();
    int currentLevel = 0;
    Vector2 targetPosition = Vector2.zero;
    string targetPositionKey = "";

    currentLevel = entity.GetCurrentLevel();
    targetPosition = entity.GetCurrentPosition() + move;
    targetPositionKey = targetPosition.x.ToString() + "," + targetPosition.y.ToString();

    return track[currentLevel][targetPositionKey];
  }
}
