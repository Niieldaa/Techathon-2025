using UnityEngine;

public class EngravingChisel : MonoBehaviour
{
    [Header("Engraving Settings")]
    public GameObject engravingPointPrefab;
    public float engravingRange = 0.2f; // optional raycast distance

    private bool hammerTouching = false;
    private bool rockTouching = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hammer"))
            hammerTouching = true;

        if (collision.collider.CompareTag("Rock"))
            rockTouching = true;

        // Only spawn if both are touching
        if (hammerTouching && rockTouching)
            SpawnEngraving(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Hammer"))
            hammerTouching = false;

        if (collision.collider.CompareTag("Rock"))
            rockTouching = false;
    }

    void SpawnEngraving(Collision collision)
    {
        // Use first contact point for simplicity
        ContactPoint contact = collision.contacts[0];

        // Spawn engraving point on the rock
        Instantiate(engravingPointPrefab, contact.point, Quaternion.LookRotation(contact.normal));

        Debug.Log("Engraved at: " + contact.point);
    }
}
