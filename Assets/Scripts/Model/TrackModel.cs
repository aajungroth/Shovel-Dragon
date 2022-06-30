using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // List of level text files
  public List<string> trackText;

  // List of objects in the game that the player interacts with
  // that are not tiles or decorations
  public List<GameObject> interactableList;

  // Reads in a list of levels
  private TrackReader trackReader;

  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // Start is called before the first frame update
  void Start() {
    trackReader = gameObject.GetComponent<TrackReader>();
    track = trackReader.readTrack(trackText);
  }

  // Update is called once per frame
  void Update() {
    
  }

  // Takes the player's move and updates game state accordingly
  public void executeTurn(Vector2 move, string ability) {
    
  }
}
