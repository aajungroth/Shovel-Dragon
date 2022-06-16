using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Each track is a list of levels that can be progressed through
    public List<IDictionary<string, bool>> readTrack(List<string> trackText) {
      List<IDictionary<string, bool>> track = new List<IDictionary<string, bool>>();

      return track;
    }

    // Each level is represented as a dictionary with coordinates as keys and
    // booleans as values to represent squares that can be walked on
    private IDictionary<string, bool> readLevel(string levelText) {
      IDictionary<string, bool> level = new Dictionary<string, bool>();

      return level;
    }
}
