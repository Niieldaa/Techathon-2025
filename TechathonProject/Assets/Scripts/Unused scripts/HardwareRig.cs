using UnityEngine;
using Fusion;

public class HardwareRing : NetworkBehaviour
{
    [Networked] public NetworkTransform networkTransform { get; private set; }

    public float rotationSpeed = 50f;

    private void Update()
    {
        if (IsOwner)  // Only the owner should control this object
        {
            float rotationInput = Input.GetAxis("Horizontal");
            RotateRing(rotationInput);
        }
    }

    private void RotateRing(float rotationInput)
    {
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}