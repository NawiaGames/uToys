using UnityEngine;

public class ParticleSystemWin : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystemsWin;

    private void PlayParticleSystem()
    {
        foreach (var particleSystem in _particleSystemsWin)
        {
            particleSystem.Play();
        }
    }

    private void OnEnable()
    {
        EventManager.PlayParticleSystemWin += PlayParticleSystem;
    }

    private void OnDisable()
    {
        EventManager.PlayParticleSystemWin -= PlayParticleSystem;
    }
}
