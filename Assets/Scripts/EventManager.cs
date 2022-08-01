using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<Answer> OpenedSummary;
    public static event Action<Vector3[], Vector3> ActivatedTutorial;
    public static event Action StopTutorial;
    public static event Action DeleteWagon;
    public static event Action PlayParticleSystemWin; 
    
    public static void OnOpenedSummary(Answer answer) => OpenedSummary?.Invoke(answer);

    public static void OnActivatedTutorial(Vector3[] positions, Vector3 dragDropPosition) =>
    ActivatedTutorial?.Invoke(positions,dragDropPosition);

    public static void OnStopTutorial() => StopTutorial?.Invoke();

    public static void OnDeleteWagon() => DeleteWagon?.Invoke();

    public static void OnPlayParticleSystemWin() => PlayParticleSystemWin?.Invoke(); 
}
