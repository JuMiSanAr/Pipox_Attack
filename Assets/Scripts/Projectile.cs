using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Rigidbody projectile;
	
	float projectileSpeed = 50f;

	public float despawnDistance = 10f;

	private void FixedUpdate()
	{
		base.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
		despawnDistance -= 1f * Time.deltaTime;

		if (despawnDistance < 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		if (transform.position.y > 0.5f)
		{
			projectile.AddForce(0f, -500f * Time.deltaTime, 0f);
		}

		if (transform.position.y < 0.5f)
        {
			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Object.Destroy(gameObject);
	}
}
