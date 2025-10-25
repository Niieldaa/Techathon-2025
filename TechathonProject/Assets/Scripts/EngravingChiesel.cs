using UnityEngine;

public class EngravingChisel : MonoBehaviour
{
    [Header("Engraving Settings")]
    public GameObject engravingPointPrefab;
    public float engravingRange = 0.2f; // optional raycast distance

    [SerializeField] GameObject plane;

    private bool hammerTouching = false;
    private bool rockTouching = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hammer"))
        {
            hammerTouching = true;
            plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
            

        if (collision.CompareTag("Rock"))
        {
            rockTouching = true;
            plane.GetComponent<MeshRenderer>().enabled = false;
        }

        // Only spawn if both are touching
        if (hammerTouching && rockTouching)
        {
            //SpawnEngraving(collision);
            Debug.Log("Spawn engraving now!");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Hammer"))
        {
            hammerTouching = false;
            plane.GetComponent<MeshRenderer>().material.color = Color.white;
        }
            

        if (collision.collider.CompareTag("Rock"))
        {
            rockTouching = false;
            plane.GetComponent<MeshRenderer>().enabled = false;
        }
            
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
