using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    private GameObject player;
    private GameManager gameManagerScript;
    private FieldOfView fieldOfViewScript;
    private float speed = 40f;
    private bool isAllowedToShoot = true;

    public GameObject projectile;
    public float rotationFloat;
    public float actualRotationY;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        fieldOfViewScript = GetComponent<FieldOfView>();

        InvokeRepeating("AllowToShoot", 0.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameIsActive)
        {
            if (fieldOfViewScript.canSeePlayer)
            {
                AttackPlayer();
            }
        }
    }

    private void FireProjectile()
    {

        rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        Instantiate(projectile, transform.position, transform.rotation);
    }

    private void AllowToShoot()
    {
        isAllowedToShoot = true;
    }

    public override void AttackPlayer()
    {
        Vector3 rotate = (player.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, rotate, speed * Time.deltaTime);

        if (isAllowedToShoot)
        {
            FireProjectile();
            isAllowedToShoot = !isAllowedToShoot;
        }
    }
}
