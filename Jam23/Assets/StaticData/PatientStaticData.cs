using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
  public static class PatientStaticData
  {
    public static float PickUpRange = 10f;
    
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
            { 2, 33 },
            { 3, 34 }
          }

        }
      };

    public static Dictionary<int, int> InitialPaidByLvl = new Dictionary<int, int>()
    {
      { 1, 500 },
      { 2, 750 },
      { 3, 1000 },
    };

    public static float StressPerSecond = 15f;

    public static float MinTravelDistance = 20f;
  }
}