using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private const float _buildingSize = 2.5f;
    private const float _groundPlaneSize = 12.5f;
    private const int _positionMultiplier = -1;
    private const int _buildingStartPosition = -13;

    private static int[,] _mapBalance = 
    {
        {8,8,6,6,8,8,8,6,6,8,8,8,8,6,6,8,8,8,8,8,6,6,8,8,8,8,8,6,6,8,8,8,8,8,8,8,6,6,9,9,9,9,9,9,6,6,9,9,9,9},
        {8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
        {6,1,1,6,0,1,1,6,0,6,1,1,0,6,6,0,4,4,1,1,1,1,7,6,6,0,0,6,6,1,1,8,8,1,1,6,6,1,1,1,1,7,6,0,6,8,8,1,1,6},
        {8,1,1,6,0,1,1,6,0,6,1,1,6,0,0,0,4,4,1,6,1,1,0,0,0,0,0,0,0,1,1,8,8,8,1,1,0,1,1,1,1,9,0,0,0,0,6,1,1,9},
        {8,1,1,7,0,1,1,0,0,0,1,1,6,0,5,0,4,4,1,6,1,1,6,0,0,0,0,0,6,1,1,8,8,8,8,1,1,1,1,1,1,9,6,0,6,0,6,1,1,9},
        {8,1,1,0,6,1,1,6,0,6,1,1,0,0,0,0,4,4,1,1,1,1,6,0,6,6,0,0,6,1,1,8,8,8,8,8,1,1,1,1,1,9,1,1,1,1,1,1,1,9},
        {6,1,1,0,6,1,1,6,0,6,1,1,0,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,1,1,1,1,1,6},
        {6,1,1,0,0,1,1,7,0,0,1,1,0,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,6,6,7,1,1,6},
        {8,1,1,6,0,1,1,6,0,6,1,1,0,1,1,0,4,4,0,1,1,1,0,6,6,0,0,6,6,0,0,6,6,1,1,2,1,1,1,1,1,2,1,1,8,0,8,1,1,8},
        {6,1,1,6,0,1,1,6,0,6,1,1,0,1,1,0,4,4,0,1,1,1,7,0,0,6,6,0,0,6,6,0,0,1,1,2,1,1,1,1,1,2,1,1,6,0,6,1,1,8},
        {6,1,1,0,0,1,1,0,0,0,1,1,1,1,1,2,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,6,0,6,1,1,8},
        {8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,0,5,0,1,1,6},
        {8,6,6,1,1,0,0,0,1,1,6,6,0,0,0,0,4,4,0,1,6,6,0,0,0,0,3,3,0,0,0,0,0,6,6,9,1,1,1,1,1,9,1,1,6,0,6,1,1,6},
        {8,0,0,2,2,0,0,0,3,3,0,0,0,0,0,4,4,4,4,4,4,4,4,4,4,4,3,3,4,4,4,4,4,4,4,9,1,1,1,1,1,9,1,1,6,0,6,1,1,9},
        {4,4,4,4,4,4,4,4,3,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,3,4,4,4,4,4,4,4,9,1,1,1,1,1,9,1,1,1,1,1,1,1,9},
        {4,4,4,4,4,4,4,4,3,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,3,4,4,4,4,4,4,4,9,1,1,1,1,1,9,1,1,1,1,1,1,1,9},
        {8,0,0,2,2,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,3,3,0,0,0,0,0,0,0,9,1,1,1,1,1,9,1,1,7,0,8,1,1,6},
        {8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,2,1,1,6,0,6,1,1,6},
        {8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,2,1,1,6,0,6,1,1,8},
        {0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,7,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,1,1,1,1,1,9,1,1,8,0,8,1,1,8},
        {9,9,9,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,1,1,1,1,1,9,1,1,1,1,1,1,1,8},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,8},
        {7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,6,0,8,1,1,6},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,6,0,6,1,1,6},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,8,0,6,1,1,9},
        {9,9,9,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,9,1,1,6,0,8,1,1,9},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,6,0,6,1,1,9},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,9,1,1,7,0,6,1,1,9},
        {9,1,1,0,6,6,1,1,8,6,6,0,0,0,6,6,0,0,0,1,1,6,0,0,0,1,1,0,6,0,6,0,6,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,6},
        {6,1,1,0,0,0,1,1,8,4,4,4,4,4,4,4,4,4,0,1,1,0,6,6,7,1,1,6,1,1,1,1,0,1,1,6,1,1,1,1,1,0,1,1,1,1,1,1,1,6},
        {6,1,1,6,8,0,1,1,8,4,4,4,4,4,4,4,4,4,0,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,0,0,0,6,6,8,1,1,9},
        {7,1,1,6,8,0,1,1,8,4,4,4,4,4,4,4,4,4,0,1,1,1,1,1,1,1,1,6,1,1,6,7,0,1,1,6,1,1,1,1,1,0,0,0,0,0,8,1,1,9},
        {6,1,1,0,8,6,1,1,8,4,4,4,4,4,4,4,4,4,0,0,0,0,6,6,8,1,1,0,1,1,6,0,0,1,1,0,1,1,1,1,1,0,0,6,6,0,6,1,1,9},
        {6,1,1,0,8,6,1,1,8,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,8,1,1,6,1,1,1,1,1,1,1,6,1,1,1,1,1,6,0,6,6,0,6,1,1,6},
        {9,1,1,0,8,0,1,1,8,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,8,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,6,0,0,0,0,8,1,1,6},
        {6,1,1,6,6,0,1,1,5,0,6,6,0,0,6,6,0,0,0,6,6,0,0,6,6,1,1,6,0,6,0,6,0,6,0,6,1,1,1,1,1,0,0,6,6,8,7,1,1,9},
        {6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
        {9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
        {9,6,6,9,9,9,6,6,9,9,9,9,6,6,9,9,9,9,6,6,9,9,9,9,9,6,6,9,9,9,9,9,6,6,9,9,9,9,6,6,9,9,9,6,6,9,9,6,6,9},
    };
    public GameObject Wall;
    public GameObject Trees;

    public GameObject Grass;
    public GameObject Road;
    public GameObject Water;
    public GameObject Bridge;
    public GameObject Ground;
    public GameObject Tunnel;
    public GameObject Factory;
    public GameObject Missions;
    public GameObject[] Buildings;

    public void Generate()
    {
        var x = _mapBalance.GetLength(0);
        var y = _mapBalance.GetLength(1);

        var ground = Instantiate<GameObject>(Ground);

        ground.transform.localScale = new Vector3(y * 2.5f, y * 2.5f, x * 2.5f);
        ground.transform.position = new Vector3(y * _groundPlaneSize * _positionMultiplier, 0, x * _groundPlaneSize * _positionMultiplier);

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
                if (_mapBalance[i, j] == 0)
                {
                    var cube = Instantiate<GameObject>(Grass);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 1)
                {
                    var cube = Instantiate<GameObject>(Road);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 2)
                {
                    var cube = Instantiate<GameObject>(Tunnel);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 3)
                {
                    var cube = Instantiate<GameObject>(Bridge);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 4)
                {
                    var cube = Instantiate<GameObject>(Water);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 5)
                {
                    var cube = Instantiate<GameObject>(Factory);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 6)
                {
                    var randomBuildingIndex = random.Next(0, Buildings.Length);

                    var height = random.NextDouble();
                    var cube = Instantiate<GameObject>(Buildings[randomBuildingIndex]);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float) ((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);
                }
                if (_mapBalance[i, j] == 7)
                {
                    var cube = Instantiate<GameObject>(Missions);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }
                if (_mapBalance[i, j] == 8)
                {
                    var cube = Instantiate<GameObject>(Trees);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                    for (var k = 0; k < cube.transform.childCount; k++)
                    {
                        var child = cube.transform.GetChild(k);
                        var active = random.NextDouble();
                        if (active < 0.5)
                            child.transform.localScale = new Vector3(child.transform.localScale.x + (float)active, child.transform.localScale.y + (float)active, child.transform.localScale.z + (float)active);
                        else
                            child.SetActive(false);
                    }

                }
                if (_mapBalance[i, j] == 9)
                {
                    var cube = Instantiate<GameObject>(Wall);

                    cube.transform.localScale = new Vector3(_buildingSize, (float)(_buildingSize), _buildingSize);
                    cube.transform.position = new Vector3(xPosition, (float)((_buildingSize) / 2f), zPosition);

                    cube.transform.SetParent(ground.transform);

                }

                xPosition = xPosition - 25;
            }

            xPosition = _buildingStartPosition;
            zPosition = zPosition - 25;
        }
    }
}
