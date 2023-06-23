using System.Collections.Generic;
using UnityEngine;
using UserData;

namespace StaticData
{
  public static class StoryGenerator
  {
    public static string GenerateDiseaseStory()
    {
      return "test";
    }

    public static string GenerateDiseaseAnnotation()
    {
      return "test";
    }

    public static Dictionary<Disease, string> DiseaseNames = new Dictionary<Disease, string>()
    {
      { Disease.PTSD, "ПТСР" },
      { Disease.Depression, "Депресія" },
      { Disease.Phobia, "Фобія" },
      { Disease.Anxiety, "Тривога" },
      { Disease.Stress, "Стрес" },
      { Disease.ED, "РХП" },
    };

    public static Dictionary<int, string> LvlNames = new Dictionary<int, string>()
    {
      { 1, "Легка" },
      { 2, "Середня" },
      { 3, "Важка" },
    };
  }

  public class DiseaseData
  {
    public Disease Disease;
    public Color Color;
    public int Lvl;
    
    
  }
}