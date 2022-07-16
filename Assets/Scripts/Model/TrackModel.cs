using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // Reads in a list of levels
  private TrackReader trackReader;

  // List of level text files
  public List<string> trackText;

  // Start is called before the first frame update
  void Start() {
    // Read in the track
    trackReader = gameObject.GetComponent<TrackReader>();
    track = trackReader.readTrack(trackText);
  }

  // Get the track of levels
  public List<IDictionary<string, bool>> GetTrack() {
    return track;
  }
}
