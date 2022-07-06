using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib.UI;


namespace TemplateProject
{
    public class UIInfoManager : UIInfoLabelManager
    {
        [SerializeField] string ballHitInfoText = "Hit!";
        [SerializeField] Color ballHitInfoColor = new Color(.32f, 1f, 1f, 1f);
        private void OnEnable()
        {
            DefaultBall.onHit += ShowHitInfo;
        }
        private void OnDisable()
        {
            DefaultBall.onHit -= ShowHitInfo;            
        }
        void ShowHitInfo(MonoBehaviour sender) => ShowTextPopup(sender.transform.position, ballHitInfoText, ballHitInfoColor);
    }

}

