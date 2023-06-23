using System;
using System.Collections.Generic;
using UnityEngine;
using UserData;

namespace StaticData
{
  public static class StoryGenerator
  {
    public static PatientStoryData GenerateDiseaseStory(UserManager manager)
    {
      var rand = new System.Random();
      var id = rand.Next(0, PatientStaticData.PatientProfiles.Count);
      var p = PatientStaticData.PatientProfiles[id];

      var resp = $"{p.Name}, {p.Age} років, {p.City}. Через пережите за останні півтора роки пасажира турбує ";

      foreach (var pair in manager.CurrentPatient.GetPatientDiseases())
      {
        var lvl = LvlNames[pair.Value];
        var disease = DiseaseNames[pair.Key];
        var avoid = DiseaseAvoidStrings[pair.Key];
        var str = $"{disease}, {lvl} стадія, {avoid}, ";
        resp += str;
      }
      return new PatientStoryData(){Photo = p.Photo, Story = resp};
    }

    public static string GenerateDiseaseAnnotation(UserManager manager)
    {
      return "test";
    }

    public static string GenerateDiseaseAnnotation(DiseaseData data)
    {
      var name = DiseaseNames[data.Disease];
      var lvl = LvlNames[data.Lvl];
      return $"{name} | Ступінь: {lvl}";
    }

    public static List<DiseaseData> GenerateDiseaseData(Dictionary<Disease, int> dis)
    {
      List<DiseaseData> resp = new List<DiseaseData>();
      foreach (var pair in dis)
      {
        resp.Add(new DiseaseData()
        {
          Disease = pair.Key,
          Lvl = pair.Value,
          Color = ColorPerDisease[pair.Key]
        });
      }
      return resp;
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

    public static Dictionary<Disease, Color> ColorPerDisease = new Dictionary<Disease, Color>()
    {
      { Disease.PTSD, new Color(1,1,0, 0.5f) },
      { Disease.Depression, new Color(1,0,1, 0.5f) },
      { Disease.Phobia, new Color(1,0,0, 0.5f) },
      { Disease.Anxiety, new Color(0,1,0, 0.5f) },
      { Disease.Stress, new Color(0,0,1, 0.5f) },
      { Disease.ED, new Color(0,1,1, 0.5f) },
    };

    public static Dictionary<int, string> LvlNames = new Dictionary<int, string>()
    {
      { 1, "Легка" },
      { 2, "Середня" },
      { 3, "Важка" },
    };

    public static Dictionary<Disease, string> DiseaseAvoidStrings = new Dictionary<Disease, string>()
    {
      { Disease.PTSD, "уникайте гучних звуків або виробництва" },
      { Disease.Depression, "уникайте води" },
      { Disease.Phobia, "унекайте темряви" },
      { Disease.Anxiety, "уникайте мостів" },
      { Disease.Stress, "уникайте швидкості вище 70км/г" },
      { Disease.ED, "уникайте різких поворотів ліворуч" },
    };

  }

  public class DiseaseData
  {
    public Disease Disease;
    public Color Color;
    public int Lvl;
  }

  public class PatientStoryData
  {
    public string Story;
    public Sprite Photo;
  }
}