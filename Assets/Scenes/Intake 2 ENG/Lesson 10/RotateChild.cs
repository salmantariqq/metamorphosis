using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChild : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public GameObject child;  // Reference to the child object
    public float speed = 20f; // Speed of rotation

    void Update()
    {
        // Get the player's rotation as Euler angles
        float playerRotationY = player.transform.eulerAngles.y;
        
        // Convert the player's rotation to radians for trigonometry calculations
        float playerRotationYRad = playerRotationY * Mathf.Deg2Rad;
        
        // Calculate the child's position relative to the player
        Vector3 relativePos = new Vector3(Mathf.Sin(playerRotationYRad), 0, Mathf.Cos(playerRotationYRad));

        // Update the child's position
        child.transform.position = player.transform.position + relativePos;
        
        // Rotate the child around the player
        child.transform.RotateAround(player.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}