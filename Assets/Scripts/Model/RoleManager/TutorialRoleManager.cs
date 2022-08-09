using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoleManager : RoleManager {
  // The references to the GameObject entities that will be assigned the roles
  // public EntityModel emoteMonster;

  public List<EntityModel> doorList;
  public List<EntityModel> keyList;
  public List<EntityModel> mapList;

  // The names of the roles
  // public const string emoteMonsterRole = "emote";

  public const string doorRole = "door";
  public const string keyRole = "key";
  public const string mapRole = "map";

  // Awake is called before any other Start method
  void Awake() {
    // AssignRole(emoteMonster, emoteMonsterRole);

    AssignRoleList(doorList, doorRole);
    AssignRoleList(keyList, keyRole);
    AssignRoleList(mapList, mapRole);
  }
}
