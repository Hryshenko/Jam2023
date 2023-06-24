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
    public float ExpectedArrivalTime;

    public Vector2 Destination;

    public PickedPatient(Patient patient, float time, Vector2 carPos)
    {
      Patient = patient;
      PickUpTime = time;
      StressPercent = 0;

      GenerateDestination(carPos);
      GenerateExpectedArrivalTimeTime();
    }

    public int CalculatePaid()
    {
      var initialPaid = Patient.InitialPaid;

      var timeLeft = (int)(ExpectedArrivalTime - Time.time);
      
      var tax = initialPaid + 20 * timeLeft;
      return (int)tax;
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

    private void GenerateExpectedArrivalTimeTime()
    {
      var rand = new Random();
      var time = rand.Next(50, 80) + Time.time;
      ExpectedArrivalTime = time;
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