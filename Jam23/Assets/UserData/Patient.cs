using System;
using System.Collections.Generic;

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
      for (var i = 0; i < difficultyLvl; i++)
        Diseases.Add((Disease) rand.Next(1, difficultyLvl + 1));
    }
  }
}