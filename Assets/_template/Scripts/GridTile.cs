using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

namespace TemplateProject
{
    [SelectionBase]
    public class GridTile : ActivatableObject
    {
        public Vector3 GetTileSize() => GetComponent<BoxCollider>().bounds.size;
        [SerializeField] Transform tileContainer = null;
        [SerializeField] AnimationCurve shakeCurve = new AnimationCurve();
        [SerializeField] float animationTime = 1f;
        float timer = float.MaxValue;
        float animationProgress = 0f;

        public void ShakeTile()
        {
            timer = 0f;
            animationProgress = 0f;
        }

        private void Update()
        {
            if (timer > 1f) return;
            tileContainer.localPosition = new Vector3(0f, shakeCurve.Evaluate(animationProgress) , 0f);
            timer += Time.deltaTime;
            animationProgress = timer / animationTime;
        }
    }
}