using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class PanelResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTitleLevel;

    private const string _levelFail = "LEVEL FAIL";
    private const string _levelOk = "LEVEL OK";
    private const string _levelKink = "LEVEL KINK";

    public void OpenPanel(Answer answer)
    {
        switch(answer)
        {
            case Answer.Fail:
                LevelFail();
                break;
            case Answer.Ok:
                LevelOk();
                break;
            case Answer.King:
                LevelKink();
                break;
        }
    }

    private void LevelFail()
    {
        _textTitleLevel.text = _levelFail;
    }

    private void LevelOk()
    {
        _textTitleLevel.text = _levelOk;
    }

    private void LevelKink()
    {
        _textTitleLevel.text = _levelKink;
    }
}
