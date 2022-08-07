using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour {
  protected void AssignRole(EntityModel entity, string role) {
    entity.SetRole(role);
  }

  protected void AssignRoleList(List<EntityModel> entityList, string role) {
    int count = 0;

    foreach(EntityModel entity in entityList) {
      entity.SetRole(role + count.ToString());
      count++;
    }
  }
}
