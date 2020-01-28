using System.Collections;
using UnityEngine;

public class ThingDisplayer : MonoBehaviour {
	public GameObject Thing;

	public Vector2 TimeRange;

	public GameObject WaitText;
	public GameObject P1Text;
	public GameObject P2Text;
	private Coroutine RunningRoutine;

	public bool IsOnDisplay { private set; get;}

	void Start () {
		Go();
	}

	public void Go()
	{
		Stop();
		WaitText.SetActive(true);
		float DisplayTime = Random.Range(TimeRange.x, TimeRange.y);
		RunningRoutine = StartCoroutine(ShowThingAfterTime(DisplayTime));
	}

	public void Stop()
	{
		Thing.SetActive(false);
		P1Text.SetActive(false);
		P2Text.SetActive(false);
		IsOnDisplay = false;
		if (RunningRoutine != null)
		{
			StopCoroutine(RunningRoutine);
		}
	}

	IEnumerator ShowThingAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		Thing.SetActive(true);
		WaitText.SetActive(false);
		P1Text.SetActive(true);
		P2Text.SetActive(true);
		IsOnDisplay = true;
	}
}
