using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResetter : MonoBehaviour
{
    public ScoreGiver MyScoreGiver;
    public ThingDisplayer MyThingDisplayer;
    public InputReader MyInputReader;
    public WinnerDecider MyWinnerDecider;
    public GameObject InstructionText;

    public float DelayDuration = 0.1f;
    public bool IsActive {private set; get;}

    private float TimePassed;

    void Start()
    {
        InstructionText.SetActive(false);
    }
    public void SetIsActive()
    {
        IsActive = true;
        StartCoroutine(ShowInstructionTextAfterWait());
    }
    
    void Update()
    {
        if (IsActive == false)
        {
            return;
        }

        TimePassed += Time.deltaTime;

        if (TimePassed < DelayDuration)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            MyScoreGiver.Reset();
            MyThingDisplayer.Go();
            MyInputReader.Go();
            IsActive = false;
            TimePassed = 0;
            InstructionText.SetActive(false);
            MyWinnerDecider.ResultText.gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowInstructionTextAfterWait()
    {
        yield return new WaitForSeconds(DelayDuration);
        InstructionText.SetActive(true);
    }
}
