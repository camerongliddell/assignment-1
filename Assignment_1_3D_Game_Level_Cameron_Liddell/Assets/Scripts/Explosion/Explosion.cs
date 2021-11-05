using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    public bool hasExploded = false;

    public void Explode()
    {
        if (!hasExploded)
        {
            // Set explosion to var to be able to destroy later
            GameObject expl = Instantiate(explosionEffect, transform.position, transform.rotation);
            // Add colliders to array for contact
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearby in colliders) // Loop through colliders
            {
                Rigidbody rb = nearby.GetComponent<Rigidbody>(); // Finds the current rigidbodies
                if (rb != null) // Checks if it is a rigib body or not
                {
                    // If rigid body, add the explosion force to it
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }

            // Start the coroutine to destroy both the object and the explosion GameObject
            StartCoroutine(DestroyExplosion());
            hasExploded = true; // Set to true because is now exploded

            IEnumerator DestroyExplosion() // Coroutine for waiting 2 seconds before destroying
            {
                Debug.Log("Starting destroy..."); // Log for debugging

                yield return new WaitForSeconds(2); // Wait for 2 seconds

                Destroy(expl); // Destroy the explosion particle effect
                Destroy(gameObject); // Destroy the handler
                Debug.Log("Destroyed!"); // Log for debugging
            }
        }
    }

    
}