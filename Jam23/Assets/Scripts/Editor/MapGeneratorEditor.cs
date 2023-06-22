using UnityEngine;
using UnityEditor;

public class MapGeneratorEditor : MonoBehaviour
{
    [MenuItem("Map/Generate", false, 100)]
    public static void Generate()
    {
        var generator = FindObjectOfType<MapGenerator>();
        generator.Generate();
    }
}
