using UnityEngine;
using System.Collections;

public interface IWeapon {

    void Shoot(GameObject npcEnemy);
    
    void StopShooting();

    int WeaponDamage{get; set;}
}
