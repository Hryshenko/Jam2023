using System;
using System.Collections.Generic;
using StaticData;

namespace UserData
{
  public class Patient
  {
    public int StressLvl = 0;
    public List<Disease> Diseases;
    public int InitialPaid;

    private static Random _random = new Random(); 

    public Patient(int difficultyLvl)
    {
      Diseases = new List<Disease>();

      var rand = new Random();
      var num = rand.Next(0, 100);
      var countOfDeseases = 0;

      foreach (var pair in PatientStaticData.DiseasesChancesPerLvl[difficultyLvl])
      {
        if (num < pair.Value)
        {
          countOfDeseases = pair.Key;
          break;
        }
      }
      
      for (var i = 0; i < countOfDeseases; i++)
        Diseases.Add((Disease) rand.Next(1, difficultyLvl + 1));
    }
  }
}