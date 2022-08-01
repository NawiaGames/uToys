using UnityEngine;

public class ParticleSystemSmoke : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystemSmoke;
    [SerializeField] private int _maxParticles = 1000;
    [SerializeField] private int _minParticles = 15;

    public void IncreaseParticles() => _particleSystemSmoke.maxParticles = _maxParticles;

    public void ReduceParticles() => _particleSystemSmoke.maxParticles = _minParticles;
}