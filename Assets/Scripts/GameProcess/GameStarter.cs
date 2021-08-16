using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class GameStarter : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent OnStarting;
    [SerializeField] private UnityEvent OnRestarting;

    public event Action OnStartedAction;


    public void StartGame()
    {
        OnStarting?.Invoke();
        OnStartedAction?.Invoke();
    }


    public void RestartGame()
    {
        OnRestarting?.Invoke();
    }
}
