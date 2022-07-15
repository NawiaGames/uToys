using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SelectObjects _selectObjects;
    [SerializeField] private Platform _platform;
    [SerializeField] private Animator _animator;
    [SerializeField] private FollowerPath _followerPath;
    [SerializeField] private ParticleSystem _particleSystemSmoke;
    public SelectObjects SelectObjects => _selectObjects;
    public Platform Platform => _platform;
    public Animator Animator => _animator;

    public FollowerPath FollowerPath => _followerPath;

    public ParticleSystem ParticleSystemSmoek => _particleSystemSmoke;
}