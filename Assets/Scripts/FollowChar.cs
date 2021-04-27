using UnityEngine;

public class FollowChar : MonoBehaviour
{
	public GameObject character;

	public Vector3 offset;

	public float startFollow;

	private GameObject mainCamera;

	private Animator cameraAnimator;

	private void Start()
	{
		startFollow = character.GetComponent<Character>().inputDelay;
	}

	private void Update()
	{
		Invoke("followChar", startFollow);
	}

	private void followChar()
	{
		base.transform.position = character.transform.position + offset;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		cameraAnimator = mainCamera.GetComponent<Animator>();
		cameraAnimator.applyRootMotion = true;
	}
}
