using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform characterPosition;

	public GameObject projectile;

	private GameObject character;

	private bool shootDelay;

	private float shootingCounter;

	public float firingSpeed;

	private void Start()
	{
		character = GameObject.FindGameObjectWithTag("Character");
	}

	private void FixedUpdate()
	{
		shootDelay = character.GetComponent<Character>().blockInput;
		base.transform.position = characterPosition.position;
		Plane plane = new Plane(Vector3.up, base.transform.position);
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		float enter = 0f;
		if (plane.Raycast(ray, out enter))
		{
			Quaternion b = Quaternion.LookRotation(ray.GetPoint(enter) - base.transform.position);
			b.x = 0f;
			b.z = 0f;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 100f * Time.deltaTime);
		}
		if (Input.GetMouseButton(1) && !shootDelay && shootingCounter >= firingSpeed)
		{
			Shoot();
			shootingCounter = 0f;
		}
		shootingCounter += Time.deltaTime;
	}

	private void Shoot()
	{
		Vector3 position = base.transform.TransformPoint(Vector3.forward);
		Object.Instantiate(projectile, position, base.transform.rotation);
	}
}
