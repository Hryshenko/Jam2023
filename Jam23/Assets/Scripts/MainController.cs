using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawner;
	public GameObject CameraController;

    public static MainController Instance;
    public static CarController PlayerCar { get { return Instance.m_PlayerCar; } }

    private CarController m_PlayerCar;

	private void Awake()
	{
		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	public void StartGame()
	{
		Player.SetActive(true);
		CameraController.SetActive(true);

		var point = Spawner.GetComponent<UserSpawner>().SpawnPoint();
		Player.transform.position = new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z);

		m_PlayerCar = Player.GetComponent<CarController>();

		var userControl = m_PlayerCar.GetComponent<UserControl>();
		var audioListener = m_PlayerCar.GetComponent<AudioListener>();

		if (userControl == null)
			userControl = m_PlayerCar.gameObject.AddComponent<UserControl>();

		if (audioListener == null)
			audioListener = m_PlayerCar.gameObject.AddComponent<AudioListener>();

		userControl.enabled = false;
		audioListener.enabled = false;

		m_PlayerCar.GetComponent<UserControl>().enabled = true;
		m_PlayerCar.GetComponent<AudioListener>().enabled = true;
	}
}
