using System.Collections;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodEffect;
    CapsuleCollider capsuleCollider;

    [SerializeField] private int health = 3;

    private Coroutine currentDamagaRoutine;

    void Start()
    {
        currentDamagaRoutine = null;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        if (currentDamagaRoutine == null)
        {
            currentDamagaRoutine = StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown()
    {
        capsuleCollider.enabled = false;
        bloodEffect.Play();
        health--;
        yield return new WaitForSeconds(1f);
        currentDamagaRoutine = null;
        capsuleCollider.enabled = true;
    }

    public int GetHealth() { return health; }
}
