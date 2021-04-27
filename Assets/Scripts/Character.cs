using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	public Rigidbody charMov;

	public float moveForce = 10f;

	public float inputDelay = 7f;

	public bool blockInput = true;

	public int lives = 3;

	public GameObject live1;
	public GameObject live2;
	public GameObject live3;

	public GameObject manager;

	public AudioSource loop;

	public bool isCaptainAmerica = true;

	public Animator animator;	

	float hurtTime = 2f;
	bool hurt = false;

	public AudioSource ouch;

	int secretLimitsInteraction = 1;
	float secretInteractionTimer = 0f;

	bool limitCollision = false;

	bool isCrazyOn;

	public AudioSource limit1;
	public AudioSource limit2;
	public AudioSource limit3;

	bool limitAudio1 = false;
	bool limitAudio2 = false;
	bool limitAudio3 = false;

	float audioCounter1 = 4.97f;
	float audioCounter2 = 2.6f;
	float audioCounter3 = 5.5f;

	private IEnumerator unblockInput(float time)
	{
		yield return new WaitForSeconds(time);
		blockInput = false;
	}

	private void Start()
	{
		StartCoroutine(unblockInput(inputDelay));
	}

	private void Update()
	{
		if (this.transform.position.y < 0f)
		{
			Destroy(this.gameObject);
		}

		if (hurt && hurtTime > 0)
        {
			hurtTime -= 1f * Time.deltaTime;
        }

		if (hurt && hurtTime < 0)
        {
			hurt = false;
			hurtTime = 2f;
        }

		if (limitCollision)
        {
			secretInteractionTimer -= 1f * Time.deltaTime;
		}

		if (secretInteractionTimer < 0f)        
		{
			limitCollision = false;
		}

        if (limitAudio1)
        {
			audioCounter1 -= 1f * Time.deltaTime;

			if(audioCounter1 <= 0f)
            {
				limitAudio1 = false;
				loop.volume = 1f;
			}
        } 
		else if (limitAudio2)
        {
			audioCounter2-= 1f * Time.deltaTime;

			if (audioCounter2 <= 0f)
			{
				limitAudio2 = false;
				loop.volume = 1f;
			}
		}
		else if (limitAudio3)
        {
			audioCounter3 -= 1f * Time.deltaTime;

			if (audioCounter3 <= 0f)
			{
				limitAudio3 = false;
				loop.volume = 1f;
			}
		}
	}

	private void FixedUpdate()
	{
		if (!blockInput && (UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.RightArrow)))
		{
			charMov.AddForce(moveForce * Time.deltaTime, 0f, 0f);
		}
		if (!blockInput && (UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.LeftArrow)))
		{
			charMov.AddForce((0f - moveForce) * Time.deltaTime, 0f, 0f);
		}
		if (!blockInput && (UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.UpArrow)))
		{
			charMov.AddForce(0f, 0f, moveForce * Time.deltaTime);
		}
		if (!blockInput && (UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.DownArrow)))
		{
			charMov.AddForce(0f, 0f, (0f - moveForce) * Time.deltaTime);
		}

		if (transform.position.y > 1.5)
        {
			charMov.AddForce(0f, -500f * Time.deltaTime, 0f);
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Pipox" && lives == 3 && !hurt)
        {
			lives--;
			hurt = true;
			animator.Play("CharacterHurt");
			ouch.Play();
			live3.SetActive(false);
        }
		else if (collision.collider.tag == "Pipox" && lives == 2 && !hurt)
		{
			lives--;
			hurt = true;
			animator.Play("CharacterHurt");
			ouch.Play();
			live2.SetActive(false);
		}
		else if (collision.collider.tag == "Pipox" && lives == 1 && !hurt)
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().isCharacterDead = true;
			Destroy(this.gameObject);
			live1.SetActive(false);
			hurt = true;
			Time.timeScale = 0f;
		}

		isCrazyOn = manager.GetComponent<CrazyMode>().isCrazyModeActive;

		if (collision.collider.tag == "Limits" && secretLimitsInteraction == 1 && secretInteractionTimer <= 0f && !isCrazyOn)
		{
			loop.volume = 0.2f;
			limitAudio1 = true;
			limitCollision = true;
			secretInteractionTimer = 5f;
			limit1.Play();
			secretLimitsInteraction = 2;

			if (lives == 3)
			{
				lives--;
				hurt = true;
				live3.SetActive(false);
				animator.Play("CharacterHurt");
			}
		}
		else if (collision.collider.tag == "Limits" && secretLimitsInteraction == 2 && secretInteractionTimer <= 0f && !isCrazyOn)
		{
			loop.volume = 0.2f;
			limitAudio2 = true;
			limitCollision = true;
			secretInteractionTimer = 5f;
			limit2.Play();
			secretLimitsInteraction = 3;

			if (lives == 3)
			{
				lives--;
				hurt = true;
				live3.SetActive(false);
				animator.Play("CharacterHurt");
			}
		}
		else if (collision.collider.tag == "Limits" && secretLimitsInteraction == 3 && secretInteractionTimer <= 0f && !isCrazyOn)
		{			
				loop.volume = 0.05f;
				limitAudio3 = true;
				limitCollision = true;
				secretLimitsInteraction = 4;
				limit3.Play();			
		}
	}
}
