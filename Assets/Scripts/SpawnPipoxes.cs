using System.Collections;
using UnityEngine;

public class SpawnPipoxes : MonoBehaviour
{
	public GameObject pipox;

	public int maxPepoxes = 10;

	private float spawnDelay = 1f;

	public float spawnRatio = 1f;

	private Vector3 portal1;

	private Vector3 portal2;

	private Vector3 portal3;

	private Vector3 portal4;

	public bool introDelay = true;

	private int portalRotation = 1;

	public int pipoxCount;

	public float firstSpawnDelay = 38.5f;

	public float loopSpawnDelay = 40f;

	private void Start()
	{
		portal1 = SpawnPortals.portal1;
		portal2 = SpawnPortals.portal2;
		portal3 = SpawnPortals.portal3;
		portal4 = SpawnPortals.portal4;
		Invoke("DropSpawn", firstSpawnDelay);
		Invoke("StartSpawn", loopSpawnDelay);
	}

	private void StartSpawn()
	{
		introDelay = false;
	}

	private void Update()
	{
		StartCoroutine(ReleaseThePipoxes());
		TimeThePipoxes(spawnDelay);
	}

	public void InstaSpawn()
    {
		Object.Instantiate(pipox, new Vector3(portal1.x, portal1.y, portal1.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal2.x, portal2.y, portal2.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal3.x, portal3.y, portal3.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal4.x, portal4.y, portal4.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal1.x, portal1.y, portal1.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal2.x, portal2.y, portal2.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal3.x, portal3.y, portal3.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal4.x, portal4.y, portal4.z), Quaternion.identity);
	}

	private void DropSpawn()
	{
		Object.Instantiate(pipox, new Vector3(portal1.x, portal1.y, portal1.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal2.x, portal2.y, portal2.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal3.x, portal3.y, portal3.z), Quaternion.identity);
		Object.Instantiate(pipox, new Vector3(portal4.x, portal4.y, portal4.z), Quaternion.identity);
		pipoxCount = 4;
	}

	private IEnumerator ReleaseThePipoxes()
	{
		if (pipoxCount < maxPepoxes && !introDelay && spawnDelay == spawnRatio)
		{
			switch (portalRotation)
			{
				case 1:
					Object.Instantiate(pipox, new Vector3(portal1.x, portal1.y, portal1.z), Quaternion.identity);
					portalRotation = 2;
					pipoxCount++;
					break;
				case 2:
					Object.Instantiate(pipox, new Vector3(portal2.x, portal2.y, portal2.z), Quaternion.identity);
					portalRotation = 3;
					pipoxCount++;
					break;
				case 3:
					Object.Instantiate(pipox, new Vector3(portal3.x, portal3.y, portal3.z), Quaternion.identity);
					portalRotation = 4;
					pipoxCount++;
					break;
				case 4:
					Object.Instantiate(pipox, new Vector3(portal4.x, portal4.y, portal4.z), Quaternion.identity);
					portalRotation = 1;
					pipoxCount++;
					break;
			}
		}
		yield return new WaitForEndOfFrame();
	}

	private void TimeThePipoxes(float pipoxTimer)
	{
		if (pipoxTimer > 0f)
		{
			spawnDelay -= Time.deltaTime;
		}
		else
		{
			spawnDelay = spawnRatio;
		}
	}
}
