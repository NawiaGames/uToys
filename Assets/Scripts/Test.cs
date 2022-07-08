using DG.Tweening;
using UnityEngine;


public class Test : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(new Vector3(0, -10, 0) , 1).SetEase(Ease.InOutSine);
    }
}
