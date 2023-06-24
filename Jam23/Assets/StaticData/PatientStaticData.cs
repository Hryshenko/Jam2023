using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
  public static class PatientStaticData
  {
    public static float PickUpRange = 2000000f;
    public static int CountOfDiseases = 6;

    public static float StressIncreasePerRotateWithED = 50f;
    
    public static int[] DifficultyMilestones = new[]
    {
      1000, 5000
    };

    public static int FinalPoint = 10000;
    
    public static List<Vector2> ListOfAvailablePatientSpawnPoints = new List<Vector2>()
    {
      new Vector2(-763, -88),
      new Vector2(-616, -777),
      new Vector2(-1165, -932),
      new Vector2(-30,-813),
      new Vector2(-1094,-718),
      new Vector2(-33,-590),
      new Vector2(-458,-509),
      new Vector2(-1095,-435),
      new Vector2(-556,-277),
      new Vector2(-1183,-212),
      new Vector2(-1019,-93),
      new Vector2(-560,-70),
      new Vector2(-169,-215),
      new Vector2(-70,-144),
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
            { 2, 100 }
          }
        },
        {
          2, new Dictionary<int, int>()
          {
            { 1, 33 },
            { 2, 66 },
            { 3, 100 }
          }

        }
      };

    public static Dictionary<int, int> InitialPaidByLvl = new Dictionary<int, int>()
    {
      { 0, 500 },
      { 1, 750 },
      { 2, 1000 },
    };

    public static float StressPerSecond = 15f;

    public static float MinTravelDistance = 300f;

    public static Dictionary<string, PatientProfile> PatientEmptyProfiles = new Dictionary<string, PatientProfile>()
    {
      {"21", new PatientProfile("Олександр","Чоловік","Львів",28,"Юрист")},
      {"22", new PatientProfile("Ігор","Чоловік","Київ",34,"Архітектор")},
      {"23", new PatientProfile("Михайло","Чоловік","Харків",22,"Консультант")},
      {"24", new PatientProfile("Іван","Чоловік","Дніпро",45,"Викладач")},
      {"25", new PatientProfile("Павло","Чоловік","Луцьк",58,"Маркетолог")},
      {"26", new PatientProfile("Олег","Чоловік","Донецьк",68,"Лікар")},
      {"27", new PatientProfile("Андрій","Чоловік","Чернігів",27,"Тренер")},
      {"28", new PatientProfile("Максим","Чоловік","Хмельницький",39,"Журналіст")},
      {"29", new PatientProfile("Оксана","Жінка","Львів",27,"Інструктор")},
      {"30", new PatientProfile("Тетяна","Жінка","Луганськ",34,"Журналіст")},
    };

    public static List<PatientProfile> PatientProfiles;
  }
  
  public class PatientProfile
  {
    public Sprite Photo;
    public string Gender;
    public string Name;
    public string City;
    public int Age;
    public string Work;

    public PatientProfile(string name, string gender, string city, int age, string work)
    {
      Name = name;
      Gender = gender;
      City = city;
      Age = age;
      Work = work;
    }
  }
}