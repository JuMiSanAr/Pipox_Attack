using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public GameObject projectile;
	
	public Text ripoxScore;

	public int ripoxCount;

	public float scoreDelay = 9f;

	void Start()
    {
		this.gameObject.SetActive(false);
		Invoke("ActivateScore", scoreDelay);
    }

	private void Update()
	{
		ripoxScore.text = ripoxCount.ToString();
	}

	void ActivateScore()
    {
		this.gameObject.SetActive(true);
    }
}
