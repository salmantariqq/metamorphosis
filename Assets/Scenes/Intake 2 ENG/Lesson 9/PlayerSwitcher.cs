using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    public List<GameObject> players; // An ordered list of player characters
    private int currentPlayerIndex = 0;

    // Add a reference to the Cinemachine Virtual Camera
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        // Initialize so only the first player can move
        for (int i = 0; i < players.Count; i++)
        {
            players[i].gameObject.SetActive(i == currentPlayerIndex);
        }

        // Set the initial Follow target for the virtual camera
        if (virtualCamera != null && players.Count > 0)
        {
            virtualCamera.Follow = players[currentPlayerIndex].transform;
        }
    }

    // Cycle forward through the players
    public void SwitchPlayerForward()
    {
        // Store the current player's position
        Vector3 lastPosition = players[currentPlayerIndex].transform.position;

        // Disable current player
        players[currentPlayerIndex].gameObject.SetActive(false);

        // Cycle to next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        // Move the new player to the last player's position and enable them
        players[currentPlayerIndex].transform.position = lastPosition;
        players[currentPlayerIndex].gameObject.SetActive(true);

        // Update the Follow target of the virtual camera
        if (virtualCamera != null)
        {
            virtualCamera.Follow = players[currentPlayerIndex].transform;
        }
    }

    // Cycle backward through the players
    public void SwitchPlayerBackward()
    {
        // Store the current player's position
        Vector3 lastPosition = players[currentPlayerIndex].transform.position;

        // Disable current player
        players[currentPlayerIndex].gameObject.SetActive(false);

        // Cycle to previous player
        currentPlayerIndex = (currentPlayerIndex - 1 + players.Count) % players.Count;

        // Move the new player to the last player's position and enable them
        players[currentPlayerIndex].transform.position = lastPosition;
        players[currentPlayerIndex].gameObject.SetActive(true);

        // Update the Follow target of the virtual camera
        if (virtualCamera != null)
        {
            virtualCamera.Follow = players[currentPlayerIndex].transform;
        }
    }
    
    public void UnlockPlayer(GameObject newPlayer)
    {
        if (newPlayer != null)
        {
            // Add the new player to the list
            players.Add(newPlayer);

            // Deactivate the new player's game object initially
            newPlayer.gameObject.SetActive(false);
        }
    }
    
}
