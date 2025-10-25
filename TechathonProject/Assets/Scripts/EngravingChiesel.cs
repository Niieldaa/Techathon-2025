using UnityEngine;

public class EngravingChiesel : MonoBehaviour
{
    [Header("Engraving Settings")]
    public float engravingRange = 0.2f;
    public GameObject engravingPointPrefab;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // check if hammer hit this chisel
        if (collision.collider.CompareTag("Hammer"))
        {
            Engrave(collision);
        }
    }

    void Engrave(Collision collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            Instantiate(engravingPointPrefab, transform.position, Quaternion.identity);

        }
    }
}