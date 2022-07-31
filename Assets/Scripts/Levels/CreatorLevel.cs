using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class CreatorLevel : MonoBehaviour
{
    [SerializeField] private TrainController _trainController;
    [SerializeField] private Level[] _levels;
    [SerializeField] private PathCreator _pathCreator; 
    
    private Level[] _levelsContainer;
    private PathCreator[] _levelsPathCreator;
    private List<Vector3> _listVectorsPath; 
    public Level[] Levels => _levelsContainer;

    private void Awake()
    {
        InitializationLevel();
    }

    private void InitializationLevel()
    {
        var size = _levels.Length;
        _levelsContainer = new Level[size];
        _levelsPathCreator = new PathCreator[size];
        
        CreateLevel(size);
        CreatePath(size);

        _trainController.MoveTrain.SetPathCreator(_pathCreator);
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

    private void CreatePath(int size)
    {
        _listVectorsPath = new List<Vector3>();
        for (int i = 0; i < size; i++)
        {
            foreach (var vector3 in _levelsPathCreator[i].path.localPoints)
            {
                var worldPosition = _levelsPathCreator[i].transform.TransformPoint(vector3);
                _levelsPathCreator[i].gameObject.SetActive(false);

                _listVectorsPath.Add(worldPosition);
            }
        }

        var bezierPath = new BezierPath(_listVectorsPath.ToArray(), false, PathSpace.xyz)
        {
            GlobalNormalsAngle = 90
        };
        _pathCreator.bezierPath = bezierPath;
    }
}
