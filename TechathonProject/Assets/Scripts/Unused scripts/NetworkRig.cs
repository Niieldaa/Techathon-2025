using UnityEngine;
using Fusion;

public class NetworkRig : NetworkBehaviour
{
    [Networked] public float health { get; set; }
    [Networked] public Vector3 networkPosition { get; set; }

    private void Update()
    {
        if (IsOwner)
        {
            HandleMovement();
            HandleHealth();
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * Time.deltaTime, Space.World);
        networkPosition = transform.position;  // Update networked position
    }

    private void HandleHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }
}