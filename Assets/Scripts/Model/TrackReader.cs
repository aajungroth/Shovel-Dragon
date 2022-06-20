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

    foreach(string levelText in trackText) {
      track.Add(readLevel(levelText));
    }

    return track;
  }

  // Each level is represented as a dictionary with coordinates as keys and
  // booleans as values to represent squares that can be walked on
  private IDictionary<string, bool> readLevel(string levelText) {
    // Holds the level as string cooridinate pairs keys to boolean values
    IDictionary<string, bool> level = new Dictionary<string, bool>();

    // Holds dictionary keys
    string key = "";

    // Coutners
    int i = 0;
    int j = 0;

    // Swap variable
    int temp = 0;

    // Read in the level tile by tile as characters
    foreach(char tile in levelText) {
      if (tile == 'O') {
        key = i + "," + j;
        level.add(key, true);
        j++;
      }
      else if(tile == 'X') {
        key = i + "," + j;
        level.add(key, false);
        j++;
      }
      else {
        // New line
        i++;
      }
    }

    // Invert the values of the matrix vertically

    return level;
  }
}
