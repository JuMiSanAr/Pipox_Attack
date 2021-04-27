using System.Collections;
using UnityEngine;

public class SpawnPortals : MonoBehaviour
{
	public GameObject portal;

	public GameObject[] obstacles;

	public static Vector3 portal1;

	public static Vector3 portal2;

	public static Vector3 portal3;

	public static Vector3 portal4;

	public int maxObstaclesQuarter = 10;

	private void Awake()
	{
		StartCoroutine(CreatePortals());
		StartCoroutine(CreateObstacles());
	}

	private IEnumerator CreatePortals()
	{
		portal1 = new Vector3(UnityEngine.Random.Range(-85, -60), 0f, UnityEngine.Random.Range(85, 60));
		portal2 = new Vector3(UnityEngine.Random.Range(85, 60), 0f, UnityEngine.Random.Range(-85, -60));
		portal3 = new Vector3(UnityEngine.Random.Range(-85, -60), 0f, UnityEngine.Random.Range(-60, -85));
		portal4 = new Vector3(UnityEngine.Random.Range(85, 60), 0f, UnityEngine.Random.Range(85, 60));
		Object.Instantiate(portal, portal1, Quaternion.identity);
		Object.Instantiate(portal, portal2, Quaternion.identity);
		Object.Instantiate(portal, portal3, Quaternion.identity);
		Object.Instantiate(portal, portal4, Quaternion.identity);
		yield return new WaitForEndOfFrame();
	}

	private IEnumerator CreateObstacles()
	{
		for (int a4 = 0; a4 <= maxObstaclesQuarter; a4++)
		{
			int num = UnityEngine.Random.Range(0, obstacles.Length);
			Object.Instantiate(obstacles[num], new Vector3(UnityEngine.Random.Range(-40, -100), 0.5f, UnityEngine.Random.Range(40, -40)), Quaternion.identity);
			yield return new WaitForEndOfFrame();
		}
		for (int a4 = 0; a4 <= maxObstaclesQuarter; a4++)
		{
			int num2 = UnityEngine.Random.Range(0, obstacles.Length);
			Object.Instantiate(obstacles[num2], new Vector3(UnityEngine.Random.Range(-40, 40), 0.5f, UnityEngine.Random.Range(-40, -100)), Quaternion.identity);
			yield return new WaitForEndOfFrame();
		}
		for (int a4 = 0; a4 <= maxObstaclesQuarter; a4++)
		{
			int num3 = UnityEngine.Random.Range(0, obstacles.Length);
			Object.Instantiate(obstacles[num3], new Vector3(UnityEngine.Random.Range(40, 100), 0.5f, UnityEngine.Random.Range(-40, 40)), Quaternion.identity);
			yield return new WaitForEndOfFrame();
		}
		for (int a4 = 0; a4 <= maxObstaclesQuarter; a4++)
		{
			int num4 = UnityEngine.Random.Range(0, obstacles.Length);
			Object.Instantiate(obstacles[num4], new Vector3(UnityEngine.Random.Range(40, -40), 0.5f, UnityEngine.Random.Range(40, 100)), Quaternion.identity);
			yield return new WaitForEndOfFrame();
		}		
	}
}
