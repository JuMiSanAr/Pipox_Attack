using UnityEngine;

public class Intro : MonoBehaviour
{
	public AudioSource primePipox;

	public AudioSource gong;

	public AudioSource wind;

	private void Start()
	{
		Invoke("PlayPrimesPipox", 2f);
		Invoke("PlayGong", 10f);
	}

	private void PlayPrimesPipox()
	{
		primePipox.Play();
	}

	private void PlayGong()
	{
		gong.Play();
		wind.Play();
	}
}
