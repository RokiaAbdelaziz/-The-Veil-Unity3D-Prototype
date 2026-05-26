using UnityEngine;
using System.Collections;

public class MolotovThrower : MonoBehaviour
{
    public GameObject molotovPrefab; // Assign the Molotov prefab here
    public Transform throwPoint;    // The point where the Molotov will be spawned
    public float throwForce = 15f;  // Force applied to the Molotov
    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Change this key if needed
        {
            StartCoroutine(AnimationCoroutine());
        }
    }

    void ThrowMolotov()
    {
        // Instantiate the Molotov prefab at the throw point
        GameObject molotov = Instantiate(molotovPrefab, throwPoint.position, throwPoint.rotation);

        // Get the Rigidbody component of the instantiated Molotov
        Rigidbody rb = molotov.GetComponent<Rigidbody>();

        // Apply force to the Molotov
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        }
    }

    IEnumerator AnimationCoroutine()
    {
        anim.SetBool("throw", true); // Start throw animation
        yield return new WaitForSeconds(2f); // Wait for animation timing
        ThrowMolotov(); // Throw the Molotov
        yield return new WaitForSeconds(1f); // Wait for animation reset timing
        anim.SetBool("throw", false); // Reset throw animation
    }

    private void Start()
    {
        // Make sure no physical Molotov prefab is attached to throwPoint at runtime
        foreach (Transform child in throwPoint)
        {
            Destroy(child.gameObject); // Destroy any existing child objects under throwPoint
        }
    }
}
