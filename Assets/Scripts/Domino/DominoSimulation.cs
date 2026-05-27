using UnityEngine;
using UnityEngine.InputSystem;

public class DominoSimulation : MonoBehaviour
{
    [Header("Domino Settings")]

    public Rigidbody firstDomino;

    public Transform dominoParent;

    public float pushForce = 5f;

    public float dominoMass = 1f;

    private void Start()
    {
        UpdateDominoMass();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PushFirstDomino();
        }
    }

    void PushFirstDomino()
    {
        firstDomino.AddForce(
            firstDomino.transform.right
            * pushForce,

            ForceMode.Impulse
        );
    }

    public void SetPushForce(float value)
    {
        pushForce = value;
    }

    public void SetDominoMass(float value)
    {
        dominoMass = value;

        UpdateDominoMass();
    }

    void UpdateDominoMass()
    {
        foreach (Transform domino in dominoParent)
        {
            Rigidbody rb =
                domino.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.mass = dominoMass;
            }
        }
    }
}