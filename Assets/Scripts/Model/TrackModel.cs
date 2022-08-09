using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // List of level text files
  public List<TextAsset> trackText;

  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // Reads in a list of levels
  private TrackReader trackReader;

  // Awake is called before any other Start method
  void Awake() {
    // Get the track reader
    trackReader = gameObject.GetComponent<TrackReader>();

    // Read in the track
    track = trackReader.readTrack(trackText);
  }

  // Get the track of levels
  public List<IDictionary<string, bool>> GetTrack() {
    return track;
  }
}
