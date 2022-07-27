using PathCreation;
using UnityEngine;

public class CreatorLevelq : MonoBehaviour
{
    [SerializeField] private TrainController _trainController;
    [SerializeField] private Levelq[] _levels;

    private Levelq[] _levelsContainer;
    private PathCreator[] _levelsPathCreator;
    
    public Levelq[] Levelqs => _levelsContainer;

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
        
        _trainController.MoveTrain.SetPathCreators(_levelsPathCreator);
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
            position.x = 0;
            position.y = 0; 
         //   var rotation = _levelsContainer[i - 1].PathCreator.path.GetRotation(0.99f);
            _levelsContainer[i] = Instantiate(_levels[i], position, Quaternion.identity, thisTransform);

            _levelsPathCreator[i] = _levelsContainer[i].PathCreator;
        }
    }
}
