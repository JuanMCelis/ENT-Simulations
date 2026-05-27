using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionUI : MonoBehaviour
{
    [Header("References")]

    public TMP_Dropdown dropdown;

    public ExplosionSimulation explosionSimulation;

    [Header("Texts")]

    public TMP_Text typeText;

    public TMP_Text forceText;

    public TMP_Text radiusText;

    [Header("Sliders")]

    public Slider forceSlider;

    public Slider radiusSlider;

    void Start()
    {
        dropdown.onValueChanged
            .AddListener(ChangeExplosion);

        forceSlider.onValueChanged
            .AddListener(ChangeForce);

        radiusSlider.onValueChanged
            .AddListener(ChangeRadius);

        ChangeExplosion(0);

        RefreshUI();
    }

    void ChangeExplosion(int index)
    {
        switch (index)
        {
            case 0:

                explosionSimulation.explosionType =
                    "Dinamita";

                explosionSimulation.explosionForce =
                    500f;

                explosionSimulation.explosionRadius =
                    5f;

                break;

            case 1:

                explosionSimulation.explosionType =
                    "Granada";

                explosionSimulation.explosionForce =
                    2000f;

                explosionSimulation.explosionRadius =
                    10f;

                break;

            case 2:

                explosionSimulation.explosionType =
                    "C4";

                explosionSimulation.explosionForce =
                    10000f;

                explosionSimulation.explosionRadius =
                    20f;

                break;

            case 3:

                explosionSimulation.explosionType =
                    "Bomba Atomica";

                explosionSimulation.explosionForce =
                    1000000f;

                explosionSimulation.explosionRadius =
                    50f;

                break;
        }

        RefreshUI();
    }

    void ChangeForce(float value)
    {
        explosionSimulation.explosionForce =
            value;

        RefreshUI();
    }

    void ChangeRadius(float value)
    {
        explosionSimulation.explosionRadius =
            value;

        RefreshUI();
    }

    void RefreshUI()
    {
        typeText.text =
            "Type: " +
            explosionSimulation.explosionType;

        forceText.text =
            "Force: " +
            explosionSimulation.explosionForce
            .ToString("F0");

        radiusText.text =
            "Radius: " +
            explosionSimulation.explosionRadius
            .ToString("F1");

        forceSlider.value =
            explosionSimulation.explosionForce;

        radiusSlider.value =
            explosionSimulation.explosionRadius;
    }
}