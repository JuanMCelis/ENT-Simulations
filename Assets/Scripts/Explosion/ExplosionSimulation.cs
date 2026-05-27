using UnityEngine;
using UnityEngine.InputSystem;

public class ExplosionSimulation : MonoBehaviour
{
    [Header("Explosion Settings")]

    public float explosionForce = 2000f;

    public float explosionRadius = 10f;

    public string explosionType = "Granada";

    private void Start()
    {
        //SimulationManager.Instance
        //    .OnSimulationReset += ResetExplosion;
    }

    private void Update()
    {
        ChangeExplosionType();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Explode();
        }
    }

    void ChangeExplosionType()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            explosionType = "Dinamita";
            explosionForce = 500f;
            explosionRadius = 5f;
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            explosionType = "Granada";
            explosionForce = 2000f;
            explosionRadius = 10f;
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            explosionType = "C4";
            explosionForce = 10000f;
            explosionRadius = 20f;
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            explosionType = "Bomba Atomica";
            explosionForce = 1000000f;
            explosionRadius = 50f;
        }
    }

    void Explode()
    {
        Collider[] colliders =
            Physics.OverlapSphere(
                transform.position,
                explosionRadius
            );

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb =
                nearbyObject
                .GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explosionRadius
                );
            }
        }

        Debug.Log(
            "Explosion Type: " +
            explosionType
        );
    }

    //void ResetExplosion()
    //{
    //    Debug.Log("Explosion Reset");
    //}

    private void OnDrawGizmosSelected()
    {
        if (explosionType == "Dinamita")
            Gizmos.color = Color.yellow;

        else if (explosionType == "Granada")
            Gizmos.color = Color.red;

        else if (explosionType == "C4")
            Gizmos.color = Color.magenta;

        else if (explosionType == "Bomba Atomica")
            Gizmos.color = Color.black;

        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius
        );
    }
}