using UnityEngine;
using System.Collections;

public interface IWeapon {

    void Shoot(GameObject npcEnemy, GameObject towerWeapon);
    
    void StopShooting();

    int WeaponDamage{get; set;}
}
