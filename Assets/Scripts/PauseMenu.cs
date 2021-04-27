using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	private GameObject pauseMenu;

	private GameObject mainCamera;

	private GameObject manager;

	public bool isPaused;

	public bool startDelay = true;

	public float pauseDelay = 10f;

	public void PauseDelay()
	{
		startDelay = false;
	}

	private void Start()
	{
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		pauseMenu.SetActive(false);
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		pauseDelay = mainCamera.GetComponent<FollowChar>().startFollow;
		Invoke("PauseDelay", pauseDelay);
		manager = GameObject.FindGameObjectWithTag("GameController");
	}

	private void Update()
	{
		Pause();
	}

	public void Pause()
	{
		if (!startDelay && !isPaused && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.SetActive(value: true);
			Time.timeScale = 0f;
			isPaused = true;
			manager.GetComponent<Manager>().PauseAllAudio();
		}
		else if (!startDelay && isPaused && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.SetActive(value: false);
			Time.timeScale = 1f;
			isPaused = false;
			manager.GetComponent<Manager>().UnpauseAllAudio();
		}
	}

	public void Unpause()
	{
		if (!startDelay && isPaused)
		{
			pauseMenu.SetActive(value: false);
			Time.timeScale = 1f;
			isPaused = false;
			manager.GetComponent<Manager>().UnpauseAllAudio();
		}
	}
}
