using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab of the bullet to be instantiated.
    public float shootInterval = 1f; // Frequency of shooting in seconds.
    public float bulletSpeed = 10f;  // Speed of the bullet.
    public GameObject Player;
    private Transform _player;        // Reference to the player's transform.
    private bool playerInRange = false;  // Check if player is in range.

    void Start()
    {
        _player = Player.transform;
        StartCoroutine(ShootPlayer());
    }

    // Function to shoot towards the player.
    private void Shoot()
    {
        
        // Create a new bullet instance.
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 direction = _player.position - transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }

    IEnumerator ShootPlayer()
    {
        while(true)
        {
            if (playerInRange)
            {
                Shoot();
                Debug.Log("IsShooting");
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }

    // Check if player enters the enemy's trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("EnterCollider");
        }
    }

    // Check if player exits the enemy's trigger.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("ExitCollider");
        }
    }
}