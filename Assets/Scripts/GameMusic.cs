using UnityEngine;

public class GameMusic : MonoBehaviour
{
	public AudioSource intro;

	public AudioSource pipoxLoop;

	public AudioSource wind;

	public AudioSource pox;

	private GameObject manager;

	private bool onDeath;

	private bool trigger = true;

	public double introLength = 38.75;
	bool isIntroBeingPlayed = true;

	private void Start()
	{
		manager = GameObject.FindGameObjectWithTag("GameController");
		intro.Play();
	}

	private void Update()
	{
		onDeath = manager.GetComponent<Manager>().isCharacterDead;
		if (onDeath && trigger)
		{
			manager.GetComponent<Manager>().StopAllAudio();
			pox.Play();
			wind.Play();
			onDeath = false;
			trigger = false;
		}

		if (isIntroBeingPlayed)
        {
			introLength = introLength -= 1 * Time.deltaTime;
			if (introLength < 0)
            {
				pipoxLoop.Play();
				isIntroBeingPlayed = false;
            }
        }
	}
}
