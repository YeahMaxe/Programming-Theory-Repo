using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    private bool isAllowedToShoot = true;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AllowToShoot", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllowedToShoot)
        {
            FireProjectile();
            isAllowedToShoot = !isAllowedToShoot;
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    private void AllowToShoot()
    {
        isAllowedToShoot = true;
    }
}
