using UnityEngine;

[RequireComponent (typeof (CarController))]
public class UserControl : MonoBehaviour
{
	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
	public bool Brake { get; private set; }

	private CarController ControlledCar;

	private void Awake () =>
		ControlledCar = GetComponent<CarController>();

	private void Update() =>
		ControlledCar.UpdateControls(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetButton("Jump"));
}
