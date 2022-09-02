using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    private GameObject player;
    private GameManager gameManagerScript;
    private float speed = 3f;
    private FieldOfView fieldOfViewScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.Find("Player");
        fieldOfViewScript = GetComponent<FieldOfView>();
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


    public override void AttackPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
