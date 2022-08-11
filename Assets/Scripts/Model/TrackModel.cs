using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // The level of the track that the player begins on
  public int initialLevel = 0;

  // The level of the track that the player is currently on
  private int currentLevel = 0;

  // List of level text files
  public List<TextAsset> trackText;

  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // Reads in a list of levels
  private TrackReader trackReader;

  // Awake is called before any other Start method
  void Awake() {
    // Initialize the current level
    currentLevel = initialLevel;

    // Get the track reader
    trackReader = gameObject.GetComponent<TrackReader>();

    // Read in the track
    track = trackReader.readTrack(trackText);
  }

  // Get the current level
  public int GetCurrentLevel() {
    return currentLevel;
  }

  // Get the track of levels
  public List<IDictionary<string, bool>> GetTrack() {
    return track;
  }

  // Set the current level
  public int SetCurrentLevel(int level) {
    currentLevel = level;
    return currentLevel;
  }
}
