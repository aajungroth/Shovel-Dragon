using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleModel : EntityModel {
  // The size the hole will default to win the game starts
  public char defaultSize = 'S';

  // The starting position of the hole
  public Vector2 initialPosition;

  // Sprite for large holes certain entities can be burried in
  public Sprite largeHole;

  // Sprite for medium holes certain entities can be stuck in
  public Sprite mediumHole;

  // The public property for the size variable
  public char Size {
    get {
      return size;
    }
    set {
      size = value;
      updateSprite(size);
    }
  }

  // Sprite for small holes that can be walked over
  public Sprite smallHole;

  // The size of the hole which can be small (S), medium (M), or large (L)
  private char size;

  // Awake is called before any other Start method
  void Awake() {
    // Ensures the private and public Size variables match when the scene loads
    updateSprite(defaultSize);
  }

  // Destroys the hole's GameObject
  public void fillHole() {
    Destroy(gameObject);
  }

  // Updates the Hole GameObject's sprite renderer to have the correct sprite
  private void updateSprite(char size) {
    // The Hole's sprite renderer
    SpriteRenderer holeSpriteRenderer = gameObject
      .GetComponent<SpriteRenderer>();
    
    // The sprite that renderer should be updated to render based on the size
    // defaults to the current sprite in case an invalid size is passed in
    Sprite updatedSprite = holeSpriteRenderer.sprite;

    // Selects the sprite based on the size
    if (size == 'L') {
      updatedSprite = largeHole;
    }
    else if (size == 'M') {
      updatedSprite = mediumHole;
    }
    else if (size == 'S') {
      updatedSprite = smallHole;
    }

    // Only updates the sprite renderer if the sprite is different
    if (holeSpriteRenderer.sprite != updatedSprite) {
      holeSpriteRenderer.sprite = updatedSprite;
    }
  }
}
