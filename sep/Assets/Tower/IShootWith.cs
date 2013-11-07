using UnityEngine;
using System.Collections;

public interface IShootWith  {

    void Shoot(GameObject npcEnemy, GameObject towerWeapon);
    
    void StopShooting();

    int WeaponDamage{get; set;}
}
