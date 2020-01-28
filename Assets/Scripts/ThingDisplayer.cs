using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThingDisplayer : MonoBehaviour {
	public GameObject Thing;

	public Vector2 TimeRange;

	public GameObject WaitText;
	public Text P1Text;
	public Text P2Text;
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
		P1Text.color = new Color(P1Text.color.r, P1Text.color.g, P1Text.color.b, 0.3f);
		P2Text.color = new Color(P2Text.color.r, P2Text.color.g, P2Text.color.b, 0.3f);
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
		P1Text.color = new Color(P1Text.color.r, P1Text.color.g, P1Text.color.b, 1f);
		P2Text.color = new Color(P2Text.color.r, P2Text.color.g, P2Text.color.b, 1f);
		IsOnDisplay = true;
	}
}
