using UnityEngine;
using UserData;

[RequireComponent (typeof (CarController))]
public class UserControl : MonoBehaviour
{
	public UserManager UserManager;
	
	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
	public bool Brake { get; private set; }

	private CarController ControlledCar;

	private void Awake () =>
		ControlledCar = GetComponent<CarController>();


	private float pastSecondCollectorTotal;
	private float pastSecondCollectorLeft;
	
	private float secondCollectorTotal;
	private float secondCollectorLeft;
	
	private void Update()
	{
		secondCollectorTotal += Time.deltaTime;
		
		var horizontal = Input.GetAxis("Horizontal");
		if (horizontal < 0)
			secondCollectorLeft += Time.deltaTime;

		if (secondCollectorTotal > 1)
		{
			CheckPercentLeft();
			pastSecondCollectorTotal = secondCollectorTotal;
			pastSecondCollectorLeft = secondCollectorLeft;
			secondCollectorTotal = 0;
			secondCollectorLeft = 0;
		}
		
		ControlledCar.UpdateControls(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetButton("Jump"));
	}

	private void CheckPercentLeft()
	{
		var p = (pastSecondCollectorLeft + secondCollectorLeft) / (pastSecondCollectorTotal + secondCollectorTotal);
		if (p > 0.5)
		{
			UserManager.TriggerTriggerED();
			Debug.LogWarning($"LeftPercent = {p}");
		}
	}
}
