using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace UserData
{
  public class PickedPatient
  {
    public Patient Patient;
    public float PickUpTime;
    public float StressPercent;
    public float ExpectedTravelTime;

    public Vector2 Destination;

    public PickedPatient(Patient patient, float time)
    {
      Patient = patient;
      PickUpTime = time;
      StressPercent = 0;

      GenerateDestination();
    }

    public int CalculatePaid()
    {
      return Patient.InitialPaid;
    }

    public void IncreaseStress(float stressPoints)
    {
      StressPercent += stressPoints;
    }

    public bool CheckIsTrigger(Disease disease)
    {
      return Patient.Diseases.Contains(disease);
    }

    private void GenerateExpectedTravelTime()
    {
      var rand = new Random();
      var time = rand.Next(30, 60);
      ExpectedTravelTime = time;
    }

    private void GenerateDestination()
    {
      var dest = new Vector2(1, 1);
      Destination = dest;
    }

    public Dictionary<Disease, int> GetPatientDiseases()
    {
      var dis = new Dictionary<Disease, int>();

      foreach (var disease in Patient.Diseases)
      {
        if (!dis.ContainsKey(disease))
          dis.Add(disease, 1);
        else
          dis[disease]++;
      }

      return dis;
    }
  }
}