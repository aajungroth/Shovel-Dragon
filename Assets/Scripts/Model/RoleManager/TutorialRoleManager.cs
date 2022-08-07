using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoleManager : RoleManager {
  // The references to the GameObject entities that will be assigned the roles
  public List<EntityModel> doorList;
  public List<EntityModel> keyList;
  public List<EntityModel> mapList;

  public EntityModel emoteMonster;

  // The names of the roles
  public const string doorRole = "door";
  public const string keyRole = "key";
  public const string mapRole = "map";

  public const string emoteMonsterRole = "emote";

  // Awake is called before any other Start method
  void Awake() {
    AssignRoleList(doorList, doorRole);
    AssignRoleList(keyList, keyRole);
    AssignRoleList(mapList, mapRole);

    AssignRole(emoteMonster, emoteMonsterRole);
  }
}
