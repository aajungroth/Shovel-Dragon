using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
  public GameObject levelClearPanel;

  // Disables player movement, digging, burrying, power up, and idle controls
  public void disablePlayerControls() {

  }

  // Covers the standard UI and enables the level clear screen
  public void displayLevelClear() {
    levelClearPanel.SetActive(true);
  }
}
