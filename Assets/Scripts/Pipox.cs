using UnityEngine;

public class Pipox : MonoBehaviour
{
	private GameObject character;

	public Rigidbody pipoxMov;

	public float pipoxSpeed = 10f;

	private Vector3 referencePosition;

	bool dead = false;

	float destroyCounter = 0f;

	public Animator animator;

	private void Start()
	{
		character = GameObject.FindGameObjectWithTag("Character");
	}

	private void FixedUpdate()
	{
		referencePosition = character.transform.position;
		base.transform.LookAt(referencePosition);
		base.transform.Translate(0f, 0f, pipoxSpeed * Time.deltaTime);
		if (dead)
        {
			destroyCounter += 1f * Time.deltaTime;
		}
		if (destroyCounter > 0.5f)
        {
			Destroy(this.gameObject);
        }
	}

	public void OnCollisionEnter(Collision collision)
	{		
		if (collision.collider.tag == "Projectile" && dead == false)
		{
			dead = true; 
			GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnPipoxes>().pipoxCount--;
			GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().ripoxCount++;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<CrazyMode>().ripoxCount++;			
			animator.Play("Pipox");
			GetComponent<Collider>().enabled = false;
		}
	}
}
