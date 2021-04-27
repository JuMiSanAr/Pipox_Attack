using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	private AudioSource[] allAudioSources;

	public Light light1;
	public Light light2;
	Color white = Color.white;
	public GameObject shootingPoint;
	public GameObject character;
	public GameObject pipox;
	public Material obstacles;
	public Shader standard;

	public GameObject gameOver;

	public bool isCharacterDead;

	void Start()
    {
		obstacles.shader = standard;

		light1.color = white;
		light2.color = white;

		shootingPoint.GetComponent<Shooting>().firingSpeed = 0.5f;
		character.GetComponent<Character>().moveForce = 550;
		pipox.GetComponent<Pipox>().pipoxSpeed = 10;
		GetComponent<SpawnPipoxes>().spawnRatio = 1f;
		GetComponent<SpawnPipoxes>().maxPepoxes = 10;

		character.GetComponent<Character>().lives = 3;
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1f;
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("GameRestart");		
		Time.timeScale = 1f;
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void StopAllAudio()
	{
		allAudioSources = (UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[]);
		AudioSource[] array = allAudioSources;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	public void PauseAllAudio()
	{
		allAudioSources = (UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[]);
		AudioSource[] array = allAudioSources;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Pause();
		}
	}

	public void UnpauseAllAudio()
	{
		allAudioSources = (UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[]);
		AudioSource[] array = allAudioSources;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UnPause();
		}
	}
	
	private void Update()
	{
		if (isCharacterDead)
		{
			gameOver.SetActive(value: true);
		}
	}
}
