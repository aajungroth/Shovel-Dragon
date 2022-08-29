using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : TrackController {
  public CameraController cameraController;

  protected override void resolveDoorPlayerCollision(GameObject door, GameObject player) {
    cameraController.MoveCameraRight();
  }
}
