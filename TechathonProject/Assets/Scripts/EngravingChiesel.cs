using Unity.VisualScripting;
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

        SpawnEngravingSimple(collision);

    }

    void SpawnEngravingSimple(Collider rock)
    {
        Vector3 point = transform.position;
        Vector3 normal = rock.transform.up;
        Instantiate(engravingPointPrefab, point + normal * 0.00000001f, Quaternion.LookRotation(normal));
    
    }

    private void OnTriggerExit(Collider other)
    {
        plane.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

}
