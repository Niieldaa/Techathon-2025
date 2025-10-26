using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthPoints>().TakeDamage();
        }
    }
    

}
