using UnityEngine;

// Define the IDamageable interface
public interface IDamageable
{
    void TakeDamage(float damage); // Method to handle damage
}

public class MolotovExplosion : MonoBehaviour
{
    public GameObject explosionEffect; // Drag your explosion Particle System prefab here
    public float explosionRadius = 5f; // Radius of the explosion
    public float explosionForce = 500f; // Strength of the explosion force
    public float damage = 50f; // Damage dealt to objects in the explosion

    void OnCollisionEnter(Collision collision)
    {
        // Spawn explosion effect at the collision point
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Apply explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearby in colliders)
        {
            // Apply explosion force to Rigidbody objects
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Handle damageable objects
            IDamageable damageable = nearby.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }

        // Destroy the Molotov object
        Destroy(gameObject);
    }
}
