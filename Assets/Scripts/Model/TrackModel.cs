using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackModel : MonoBehaviour {
  // The manager for interactable objects in the game
  public InteractableManager interactableManager;

  // The game object that has the player's initial state
  public PlayerModel playerModel;

  // The current position of the player in a level
  private Vector2 currentPlayerPosition;

  // The list of initial positions the player takes in each level
  private List<Vector2> initialPlayerPositionList;

  // List of objects in the game that the player interacts with
  // that are not tiles or decorations
  private List<Interactable> interactableList;

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

    // Get the player's starting positions
    initialPlayerPositionList = playerModel.initialPlayerPositionList;

    // Get the list of interactables
    interactableList = interactableManager.GetList();
  }

  // Get the current player position
  public Vector2 GetCurrentPlayerPosition() {
    return currentPlayerPosition;
  }

  // Get the list of initial player positions
  public List<Vector2> GetInitialPlayerPositionList() {
    return initialPlayerPositionList;
  }

  // Get the list of interactables
  public List<Interactable> GetInteractableList() {
    return interactableList;
  }

  // Get the track of levels
  public List<IDictionary<string, bool>> GetTrack() {
    return track;
  }

  // Updates the player's position in the model to one tile down
  public Vector2 MovePlayerDown() {
    currentPlayerPosition += Vector2.down;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile left
  public Vector2 MovePlayerLeft() {
    currentPlayerPosition += Vector2.left;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile right
  public Vector2 MovePlayerRight() {
    currentPlayerPosition += Vector2.right;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile up
  public Vector2 MovePlayerUp() {
    currentPlayerPosition += Vector2.up;
    return currentPlayerPosition;
  }
}
