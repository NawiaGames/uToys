using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateProject
{
    public class EffectsManager : MonoBehaviour
    {
        [SerializeField] ParticleSystem hitEffect = null;

        private void OnEnable()
        {   
            DefaultBall.onHit += PlayBallHitEffect;
        }
        private void OnDisable()
        {
            DefaultBall.onHit -= PlayBallHitEffect;        
        }

        void PlayBallHitEffect(MonoBehaviour sender) => PlayAtPosition(hitEffect, sender.transform.position, sender.transform.up);

        void PlayAtPosition(ParticleSystem ps, Vector3 position) => PlayAtPosition(ps, position, Vector3.up);
        void PlayAtPosition(ParticleSystem ps, Vector3 position, Vector3 direction)
        {
            ps.transform.position = position;
            ps.transform.forward = direction;
            ps.Play();
        }
    }
}