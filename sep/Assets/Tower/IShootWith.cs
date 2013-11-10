using UnityEngine;
using System.Collections;

public interface IShootWith  {

    void Shoot(GameObject npcEnemy);
    
    void StopShooting();

    int WeaponDamage{get; set;}
}
