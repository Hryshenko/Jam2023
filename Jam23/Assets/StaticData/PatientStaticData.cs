using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
  public static class PatientStaticData
  {
    public static int[] DifficultyMilestones = new[]
    {
      1000, 5000
    };

    public static int FinalPoint = 10000;
    
    public static List<Vector2> ListOfAvailablePatientSpawnPoints = new List<Vector2>()
    {

    };

    public static List<Vector2> ListOfAvailablePatientDestinationPoints = new List<Vector2>()
    {

    };

    public static Dictionary<int, Dictionary<int, int>> DiseasesChancesPerLvl =
      new Dictionary<int, Dictionary<int, int>>()
      {
        {
          0, new Dictionary<int, int>()
          {
            { 1, 100 }
          }
        },
        {
          1, new Dictionary<int, int>()
          {
            { 1, 50 },
            { 2, 50 }
          }
        },
        {
          2, new Dictionary<int, int>()
          {
            { 1, 33 },
            { 1, 33 },
            { 1, 34 }
          }

        }
      };

    public static float MinTravelDistance = 20f;
  }
}