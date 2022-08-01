using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void DeleteWagon() => EventManager.OnDeleteWagon();
}
