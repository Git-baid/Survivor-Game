using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
        if (pm.moveDir == Vector2.zero)
        {
            spawnedBullet.GetComponent<HandgunBulletBehavior>().DirectionChecker(pm.lastMoveDir);
        }
        else
        {
            spawnedBullet.GetComponent<HandgunBulletBehavior>().DirectionChecker(pm.moveDir);
        }
    }
}
