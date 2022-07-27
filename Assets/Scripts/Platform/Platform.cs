using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
 //   [SerializeField] private Renderer _renderer;
 //   [SerializeField] private Levelq _levelq;
    [SerializeField] private GameObject _gameObjectWin;
    [SerializeField] private GameObject _gameObjectFail; 
    private bool _isEmpty = true;

    public void ActivatePlacePlatform(Answer answer)
    {
        switch (answer)
        {
            case Answer.Fail:
                _gameObjectFail.SetActive(true);
                break;
            case Answer.Win:
                _gameObjectWin.SetActive(true);
                break;
            case Answer.King:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(answer), answer, null);
        }
        //_renderer.material.color = Color.green;
        //  _levelq.Outline.OutlineWidth = _levelq.WidthOutline; 
    }

    public void FreePlatform()
    {
        _gameObjectFail.SetActive(false);
        _gameObjectWin.SetActive(false);
        //_renderer.material.color = Color.gray;
       // _levelq.Outline.OutlineWidth = 0; 
    }

    public bool IsEmpty() => _isEmpty;

    public void SetIsEmpty(bool state) => _isEmpty = state; 
}
