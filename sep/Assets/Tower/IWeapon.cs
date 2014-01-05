using UnityEngine;
using System.Collections;

public interface IWeapon {
    /// <summary>
    /// Übergibt ein Gameobject an den Turm.
    /// </summary>
    /// <param name="npcEnemy"></param>
    void Shoot(GameObject npcEnemy);
    
    /// <summary>
    /// Dem Turm wird angewiessen schießen zu beenden.
    /// </summary>
    void StopShooting();

    /// <summary>
    /// Geter und Seter für Waffenschaden.
    /// </summary>
    int WeaponDamage{get; set;}

    /// <summary>
    /// Geter und Seter für Schusszeit
    /// </summary>
    float Delay { get; set; }

}
