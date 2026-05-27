using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance
    {
        get;
        private set;
    }

    [Header("Simulation Settings")]

    [Min(0.0001f)]
    public float updateTime = 0.02f;

    [Range(0f, 10f)]
    public float timeScale = 1f;

    public bool isPaused = false;

    [Header("Simulation State")]

    [SerializeField]
    private float timer = 0f;

    public float SimulationTime
    {
        get;
        private set;
    }

    public int StepCount
    {
        get;
        private set;
    }

    // EVENTS

    public event Action<float> OnSimulationStep;

    //public event Action OnSimulationReset;

    public event Action OnSimulationPause;

    public event Action OnSimulationPlay;

    private void Awake()
    {
        if (Instance != null &&
            Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        HandleInput();

        if (isPaused)
            return;

        timer +=
            Time.deltaTime * timeScale;

        while (timer >= updateTime)
        {
            Step();
            timer -= updateTime;
        }
    }

    void Step()
    {
        SimulationTime += updateTime;

        StepCount++;

        OnSimulationStep?.Invoke(updateTime);
    }

    void HandleInput()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetSimulation();
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SetTimeScale(0.2f);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SetTimeScale(1f);
        }
    }

    #region Controls

    public void Play()
    {
        isPaused = false;

        OnSimulationPlay?.Invoke();
    }

    public void Pause()
    {
        isPaused = true;

        OnSimulationPause?.Invoke();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
            OnSimulationPause?.Invoke();
        else
            OnSimulationPlay?.Invoke();
    }

    public void SetTimeScale(float scale)
    {
        timeScale =
            Mathf.Max(0f, scale);
    }

    public void SetUpdateTime(float dt)
    {
        updateTime =
            Mathf.Max(0.0001f, dt);
    }

    //public void ResetSimulation()
    //{
    //    timer = 0f;

    //    SimulationTime = 0f;

    //    StepCount = 0;

    //    OnSimulationReset?.Invoke();
    //}

    public void ResetSimulation()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
    #endregion
}