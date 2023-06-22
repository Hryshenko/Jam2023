namespace UserData
{
  public class PickedPatient
  {
    public Patient Patient;
    public float PickUpTime;

    public PickedPatient(Patient patient, float pickUpTime)
    {
      PickUpTime = pickUpTime;
      Patient = patient;
    }

    public int CalculateTax()
    {
      return Patient.InitialPaid;
    }
  }
}