using PathCreation;
using UnityEngine;

public class CreatorLevelq : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private Levelq[] _levels;

    private Levelq[] _levelsContainer;
    private PathCreator[] _levelsPathCreator;
    
    public Levelq[] _Levelqs => _levelsContainer;
    public PathCreator[] LevelsPathCreator => _levelsPathCreator;
    
    
    private void Awake()
    {
        InitializationLevel();
    }

    private void InitializationLevel()
    {
        var size = _levels.Length;
        _levelsContainer = new Levelq[size];
        _levelsPathCreator = new PathCreator[size];
        
        CreateLevel(size);
        
        _moveTrain.SetPathCreators(_levelsPathCreator);
    }

    private void CreateLevel(int size)
    {
        var thisTransform = gameObject.transform;
        _levelsContainer[0] = Instantiate(_levels[0], thisTransform);
        _levelsPathCreator[0] = _levelsContainer[0].PathCreator;
        
        for (var i = 1; i < size; i++)
        {
            var indexPosition = _levelsContainer[i - 1].PathCreator.path.NumPoints - 1;
            var position = _levelsContainer[i - 1].PathCreator.path.GetPoint(indexPosition);
            var rotation = _levelsContainer[i - 1].PathCreator.path.GetRotation(0.99f);
            _levelsContainer[i] = Instantiate(_levels[i], position, rotation, thisTransform);

            _levelsPathCreator[i] = _levelsContainer[i].PathCreator;
        }
    }
}
