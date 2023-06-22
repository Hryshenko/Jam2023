using System.Numerics;

namespace UserData
{
  public class PickedPatient
  {
    public Patient Patient;
    public float PickUpTime;
    public int StressPercent;

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

    public void IncreaseStress()
    {
      
    }

    public void GenerateDestination()
    {
      var dest = new Vector2(1, 1);
      Destination = dest;
    }
  }
}