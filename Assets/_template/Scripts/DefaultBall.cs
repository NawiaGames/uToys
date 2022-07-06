using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateProject
{
    public class DefaultBall : MonoBehaviour
    {
        public static System.Action<DefaultBall> onHit;

        [Header("Interaction Animation")]
        [SerializeField] float interactionAnimationTime = 1f;
        [SerializeField] AnimationCurve interactionCurve = new AnimationCurve();
        [SerializeField] Transform interactionTransform = null;
        float interactionAnimationTimer = float.MaxValue;

        
        private void OnTriggerEnter(Collider other) {
            other.gameObject.GetComponent<GridTile>()?.ShakeTile();
        }

        public void Interact(){
            interactionAnimationTimer = 0f;
            onHit?.Invoke(this);
        }

        private void Update() {
             if (interactionAnimationTimer > 1f) return;

             interactionTransform.localScale = Vector3.one * interactionCurve.Evaluate(interactionAnimationTimer);
             interactionAnimationTimer += Time.deltaTime;
        }
    }
}