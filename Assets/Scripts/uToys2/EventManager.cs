using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<Answer> OpenedSummary;

    public static void OnOpenedSummary(Answer answer)
    {
        OpenedSummary?.Invoke(answer);
    }
}
