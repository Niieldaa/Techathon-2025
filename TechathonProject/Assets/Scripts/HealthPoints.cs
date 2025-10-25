using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;

    [SerializeField] private int health = 3;

    void Update()
    {
        if (health <= 0)
        {
            //Player dead hehe
        }
    }

    public void TakeDamage()
    {
        bloodEffect.Play();
        Debug.Log("The player took damage");
        health--;
    }

    public int GetHealth() { return health; }
}
