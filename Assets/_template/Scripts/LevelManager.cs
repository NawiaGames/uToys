using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameLib.FSM;

namespace TemplateProject
{
    public class LevelManager : GameSystem
    {
        [Header("Tile Grid")]
        [SerializeField] GridTile gridTilePrefab = null;
        [SerializeField] Vector2Int girdSize = new Vector2Int(5,5);
        List<GridTile> gridTiles = new List<GridTile>();

        [Header("Frame")]
        [SerializeField] MeshScaler meshScaleController = null;

        [Header("Scene POI")]
        [SerializeField] GameLib.CameraSystem.CameraPOI cameraBorderL;
        [SerializeField] GameLib.CameraSystem.CameraPOI cameraBorderR;
        public Vector3[] GetLevelSize() => new Vector3[]{cameraBorderL.Position, cameraBorderR.Position};
        
        public new bool IsProcessing =>  gridTiles.Any(x => x.InTransition);

        public void SpawnBoard(int boardWidth = 5, int boardHeight = 5)
        {
            var tileSize = Vector3.one * .5f    ;
            var _centerOffsetX = boardWidth * .5f;
            var _centerOffsetY = boardHeight * .5f;
            
            meshScaleController?.SetMeshSize(_centerOffsetX, 0f, _centerOffsetY, .5f, 0f, .5f);

            for (int i = 0; i <boardWidth; i++)
                for (int j = 0; j < boardHeight; j++)
                    {
                        var newTile = Instantiate(gridTilePrefab, new Vector3((i - _centerOffsetX) + tileSize.x, 0, (j - _centerOffsetY) + tileSize.z), Quaternion.identity, this.transform);
                        gridTiles.Add(newTile);
                    }

            gridTiles.OrderByDescending(x => Vector3.Distance(x.transform.position, transform.position)).ToList().ForEach(x => x.transform.SetAsFirstSibling());

            cameraBorderL.transform.position = new Vector3(-_centerOffsetX, 0,-_centerOffsetY);
            cameraBorderR.transform.position = new Vector3( _centerOffsetX, 0, _centerOffsetY);
        }
        public void ClearLevel(){
            foreach (var tile in new List<GridTile>(gridTiles))
                Destroy(tile.gameObject);
            gridTiles.Clear();
        }
    }
}