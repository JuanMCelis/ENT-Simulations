using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DominoUI : MonoBehaviour
{
    [Header("References")]

    public DominoSimulation dominoSimulation;

    [Header("Texts")]

    public TMP_Text forceText;

    public TMP_Text massText;

    public TMP_Text countText;

    [Header("Sliders")]

    public Slider forceSlider;

    public Slider massSlider;

    void Start()
    {
        forceSlider.onValueChanged
            .AddListener(ChangeForce);

        massSlider.onValueChanged
            .AddListener(ChangeMass);

        RefreshUI();
    }

    void ChangeForce(float value)
    {
        dominoSimulation.SetPushForce(value);

        RefreshUI();
    }

    void ChangeMass(float value)
    {
        dominoSimulation.SetDominoMass(value);

        RefreshUI();
    }

    void RefreshUI()
    {
        forceText.text =
            "Push Force: " +
            dominoSimulation.pushForce
            .ToString("F1");

        massText.text =
            "Domino Mass: " +
            dominoSimulation.dominoMass
            .ToString("F1");

        countText.text =
            "Domino Count: " +
            dominoSimulation.dominoParent.childCount;

        forceSlider.value =
            dominoSimulation.pushForce;

        massSlider.value =
            dominoSimulation.dominoMass;
    }
}