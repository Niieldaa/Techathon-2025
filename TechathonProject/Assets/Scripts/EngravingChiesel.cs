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
            Engrave();
        }
    }

    void Engrave()
    {
        // cast a ray downward (from chisel tip)
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = -transform.up; // assuming chisel tip faces -Y

        if (Physics.Raycast(origin, direction, out hit, engravingRange))
        {
            if (hit.collider.CompareTag("Rock"))
            {
                // spawn engraving point at the contact
                Instantiate(engravingPointPrefab, hit.point, Quaternion.LookRotation(hit.normal));

                // optional feedback
                Debug.Log("Engraved at: " + hit.point);
            }
        }
    }
}
