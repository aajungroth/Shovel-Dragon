using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : TrackController {
  public CameraController cameraController;
  public TrackModel trackModel;

  protected override void resolveDoorPlayerCollision(GameObject door, GameObject player) {
    trackModel.SetCurrentLevel(1);
    player.GetComponent<PlayerModel>().SetCurrentLevel(1);
    player.GetComponent<PlayerModel>().SetCurrentPosition(
      player.GetComponent<PlayerModel>().initialPosition);
    player.GetComponent<PlayerModel>().SetCurrentDirection("right");
    player.transform.position += Vector3.right * 14;
    cameraController.MoveCameraRight();
  }
}
