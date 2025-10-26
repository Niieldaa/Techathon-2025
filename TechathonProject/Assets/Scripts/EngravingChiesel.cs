using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EngravingChisel : MonoBehaviour
{
    [Header("Engraving Settings")]
    public GameObject engravingPointPrefab;
    public float engravingRange = 0.2f; // optional raycast distance
    Coroutine currentCoroutine;
    public float timeBetweenHits = 1;

    [SerializeField] GameObject plane;

    private bool hammerTouching = false;
    private bool rockTouching = false;

    void Start()
    {
        currentCoroutine = null;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hammer"))
        {
            hammerTouching = true;
            //plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
            
        if (collision.CompareTag("Rock"))
        {
            rockTouching = true;
            //plane.GetComponent<MeshRenderer>().enabled = false;
        }

        // Only spawn if both are touching
        if (hammerTouching && rockTouching)
        {
            //SpawnEngraving(collision);
            Debug.Log("Spawn engraving now!");
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(SpawnEngravingSimple(collision));
            }
        }

        

    }
    
    IEnumerator SpawnEngravingSimple(Collider rock)
    {
        Vector3 point = transform.position;
        Vector3 normal = rock.transform.up;
        Instantiate(engravingPointPrefab, point + normal * 0.0001f, Quaternion.LookRotation(normal));
        yield return new WaitForSeconds(timeBetweenHits);
        currentCoroutine = null;

    }

    private void OnTriggerExit(Collider collision)
    {
        //plane.GetComponent<MeshRenderer>().material.color = Color.blue;
        if (collision.CompareTag("Hammer"))
        {
            hammerTouching = false;
            //plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
            
        if (collision.CompareTag("Rock"))
        {
            rockTouching = false;
            //plane.GetComponent<MeshRenderer>().enabled = false;
        }
    } 

}
