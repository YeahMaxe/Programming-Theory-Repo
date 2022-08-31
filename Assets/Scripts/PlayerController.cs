using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public TextMeshProUGUI LifeText;

    private float horizontalInput;
    private float verticalInput;
    private float mouseMoveX;
    private float speed = 4.0f;
    private float turnSpeed = 240.0f;
    private int playerLife = 3;
    private bool isAllowedToShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        LifeText.text = "Lifes: " + playerLife;

        InvokeRepeating("AllowToShoot", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input from Player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseMoveX = Input.GetAxis("Mouse X");

        // Move the Player
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.up, turnSpeed * mouseMoveX * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isAllowedToShoot)
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

    // Detect a collision with a projectile
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            playerLife -= 1;
            LifeText.text = "Lifes: " + playerLife;
            Destroy(other.gameObject);
        }
    }

    // Detect a collision with an Enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerLife -= 1;
            LifeText.text = "Lifes: " + playerLife;
            Destroy(collision.gameObject);
        }
    }
}