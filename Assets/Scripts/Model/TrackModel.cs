using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // List of level text files
  public List<string> trackText;

  // List of objects in the game that the player interacts with
  // that are not tiles or decorations
  public List<GameObject> interactableList;

  // The game object that has the player's initial state
  public GameObject Player;

  // Reads in a list of levels
  private TrackReader trackReader;

  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // The list of initial positions the player takes in each level
  private List<Vector2> initialPlayerPositions;

  // Start is called before the first frame update
  void Start() {
    // Read in the track
    trackReader = gameObject.GetComponent<TrackReader>();
    track = trackReader.readTrack(trackText);

    // Get player starting positions
    initialPlayerPositions = Player.GetComponent<PlayerModel>().initialPlayerPositions;
  }
}
