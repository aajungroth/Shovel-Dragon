using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : TrackController {
  public CameraController cameraController;
  public CanvasController canvasController;
  public TrackModel trackModel;

  protected override void resolveDoorPlayerCollision(GameObject door,
  GameObject player) {
    string doorRole = door.GetComponent<DoorModel>().GetRole();

    if (doorRole[doorRole.Length - 1] == '0' ||
    doorRole[doorRole.Length - 1] == '1') {
      trackModel.SetCurrentLevel(trackModel.GetCurrentLevel() + 1);
      player.GetComponent<PlayerModel>().SetCurrentLevel(
        player.GetComponent<PlayerModel>().GetCurrentLevel() + 1);
      player.GetComponent<PlayerModel>().SetCurrentPosition(
        player.GetComponent<PlayerModel>().initialPosition);
      player.GetComponent<PlayerModel>().SetCurrentDirection("right");
      player.transform.position += Vector3.right * 14;
      cameraController.MoveCameraRight();
    }
    else if (doorRole[doorRole.Length - 1] == '2') {
      canvasController.displayLevelClear();
    }
  }
}
