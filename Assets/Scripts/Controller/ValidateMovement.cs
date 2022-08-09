using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateMovement : MonoBehaviour {
  // Determines if the entity's attempted move will result in the
  // entity moving to an empty space
  public static bool IsMoveValid(Vector2 direction, GameObject entity, TrackModel trackModel) {
    List<IDictionary<string, bool>> track = trackModel.GetTrack();
    int currentLevel = 0;
    Vector2 targetPosition = Vector2.zero;
    string targetPositionKey = "";

    currentLevel = entity.GetComponent<EntityModel>().GetCurrentLevel();
    targetPosition = entity.GetComponent<EntityModel>().GetCurrentPosition() + direction;
    targetPositionKey = targetPosition.x.ToString() + "," + targetPosition.y.ToString();

    return track[currentLevel][targetPositionKey];
  }
}
