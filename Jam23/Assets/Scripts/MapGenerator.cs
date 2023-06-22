using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private const int _buildingSize = 10;
    private const int _groundPlaneSize = 5;
    private const int _positionMultiplier = -1;
    private const int _buildingStartPosition = -5;

    private static int[,] _mapBalance = 
    {
        { 1, 1, 0, 1, 1 },
        { 1, 1, 0, 1, 0 },
        { 1, 0, 0, 0, 0 },
        { 1, 0, 1, 0, 0 },
        { 1, 0, 1, 1, 0 },
    };

    public GameObject Ground;
    public GameObject[] Buildings;

    public void Generate()
    {
        var x = _mapBalance.GetLength(0);
        var y = _mapBalance.GetLength(1);

        var ground = Instantiate<GameObject>(Ground);

        ground.transform.localScale = new Vector3(x, y, y);
        ground.transform.position = new Vector3(x * _groundPlaneSize * _positionMultiplier, 0, y * _groundPlaneSize * _positionMultiplier);

        GenerateBuildings(ground);
    }

    private void GenerateBuildings(GameObject ground)
    {
        var random = new System.Random();
        var xPosition = _buildingStartPosition;
        var zPosition = _buildingStartPosition;

        for (var i = 0; i < _mapBalance.GetLength(0); i++)
        {
            for (var j = 0; j < _mapBalance.GetLength(1); j++)
            {
                if (_mapBalance[i, j] == 1)
                {
                    var randomBuildingIndex = random.Next(0, Buildings.Length);

                    var height = random.Next(_buildingSize, _buildingSize + 5);
                    var cube = Instantiate<GameObject>(Buildings[randomBuildingIndex]);

                    cube.transform.localScale = new Vector3(_buildingSize, height, _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (height / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                xPosition = xPosition - _buildingSize;
            }

            xPosition = _buildingStartPosition;
            zPosition = zPosition - _buildingSize;
        }
    }
}
