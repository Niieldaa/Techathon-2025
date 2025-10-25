using UnityEngine;

public class Collissions : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            // Do something here depending on tag
        }
        if (other.gameObject.CompareTag("Chissel"))
        {
            // Do something here depending on tag
        }
        if (other.gameObject.CompareTag(""))
        {
            // Do something here depending on tag
        }
    }

    void OnCollsiionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            // Do something here depending on tag
        }
        if (other.gameObject.CompareTag("Chissel"))
        {
            // Do something here depending on tag
        }
        if (other.gameObject.CompareTag(""))
        {
            // Do something here depending on tag
        }
    }

    
}
