using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHeaterController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpaceHeater = Instantiate(weaponData.Prefab);
        spawnedSpaceHeater.transform.position = transform.position; // Spawns at player position
        spawnedSpaceHeater.transform.parent = transform; // Follows player
    }
}
