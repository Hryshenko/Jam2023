using System.Collections.Generic;
using System.Linq;
using StaticData;
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

    public PickedPatient(Patient patient, float time, Vector2 carPos)
    {
      Patient = patient;
      PickUpTime = time;
      StressPercent = 0;

      GenerateDestination(carPos);
      GenerateExpectedTravelTime();
    }

    public int CalculatePaid()
    {
      return Patient.InitialPaid;
    }

    public void IncreaseStress(float deltaTime, List<Disease> diseases)
    {
      var diseaseLvl = GetPatientDiseases();
      foreach (var dis in diseases)
      {
        if (diseaseLvl.ContainsKey(dis))
        {
          StressPercent += PatientStaticData.StressPerSecond * deltaTime * diseaseLvl[dis];
        }
      }
    }

    public void InstantStressIncrease(float stressPoints)
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
      var time = rand.Next(30, 70) + Time.time;
      ExpectedTravelTime = time;
    }

    private void GenerateDestination(Vector2 carPos)
    {
      var availableDests = PatientStaticData.ListOfAvailablePatientSpawnPoints
        .Where(p => Vector2.Distance(carPos, p) >= PatientStaticData.MinTravelDistance)
        .ToList();

      var count = availableDests.Count;
      var rand = new Random();
      var id = rand.Next(0, count);

      Destination = availableDests[id];
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