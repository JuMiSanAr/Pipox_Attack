using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
	private float counter = 8f;

	private void Update()
	{
		counter -= Time.deltaTime;
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && counter > 0f)
		{
			SceneManager.LoadScene("Menu");
			base.gameObject.SetActive(value: false);
		}
	}
}
