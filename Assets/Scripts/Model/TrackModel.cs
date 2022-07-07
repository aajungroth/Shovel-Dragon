using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // The manager for interactable objects in the game
  public InteractableManager interactableManager;

  // The game object that has the player's initial state
  public PlayerModel playerModel;

  // List of level text files
  public List<string> trackText;

  // Reads in a list of levels
  private TrackReader trackReader;

  // The list of levels as matrices that tracks empty and blocked tiles
  private List<IDictionary<string, bool>> track;

  // The current position of the player in a level
  private Vector2 currentPlayerPosition;

  // The list of initial positions the player takes in each level
  private List<Vector2> initialPlayerPositions;

  // List of objects in the game that the player interacts with
  // that are not tiles or decorations
  private List<Interactable> interactableList;

  // Start is called before the first frame update
  void Start() {
    // Read in the track
    trackReader = gameObject.GetComponent<TrackReader>();
    track = trackReader.readTrack(trackText);

    // Get the player's starting positions
    initialPlayerPositions = playerModel.initialPlayerPositions;

    // Get the list of interactables
    interactableList = interactableManager.GetList();
  }
}
