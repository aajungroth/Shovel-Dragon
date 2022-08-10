using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackReader : MonoBehaviour {
  // Each track is a list of levels that can be progressed through
  public List<IDictionary<string, bool>> readTrack(List<TextAsset> trackText) {
    List<IDictionary<string, bool>> track = new List<IDictionary<string, bool>>();

    foreach (TextAsset levelText in trackText) {
      track.Add(readLevel(levelText.text));
    }

    return track;
  }

  // Each level is represented as a dictionary with coordinates as keys and
  // booleans as values to represent squares that can be walked on
  private IDictionary<string, bool> readLevel(string levelText) {
    // Holds the level as string cooridinate pairs keys to boolean values
    IDictionary<string, bool> level = new Dictionary<string, bool>();

    // Hold dictionary keys
    string key = "";
    string keyInverted = "";

    // Coutners
    int i = 0;
    int j = 0;

    // Records the max length of a row tiles
    int iMax = 0;

    // Swap variable
    bool temp = false;

    // Read in the level tile by tile as characters
    foreach (char tile in levelText) {
      if (tile == 'O') {
        // Empty tiles can be walked on
        key = i + "," + j;
        level.Add(key, true);
        i++;
      }
      else if(tile == 'X') {
        // Blocked tiles cannot be walked on
        key = i + "," + j;
        level.Add(key, false);
        i++;
      }
      else if (System.Convert.ToInt32(tile) == 10) {
        // Line Feed indicates a new row of tiles
        j++;
        iMax = i;
        i = 0;
      }
    }

    // Invert the values of the level matrix vertically
    for (int m = 0; m < iMax; m++) {
      for (int n = j - 1; n >= j / 2; n--) {
        // Assemble keys
        key = m + "," + (j - n - 1);
        keyInverted = m + "," + n;

        // Swap values
        temp = level[keyInverted];
        level[keyInverted] = level[key];
        level[key] = temp;
      }
    }

    return level;
  }
}
