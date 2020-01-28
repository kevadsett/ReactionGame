using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGiver : MonoBehaviour
{
    public ThingDisplayer MyThingDisplayer;
    public Text Player1ScoreText;
    public Text Player2ScoreText;

    public PartyPopper P1PartyPopper;
    public PartyPopper P2PartyPopper;

    public CameraShaker MyCameraShaker;

    private int Player1Score;
    private int Player2Score;

    private bool IsActive = true;

    public void OnPlayer1KeyPressed()
    {
        if (MyThingDisplayer.IsOnDisplay == false)
        {
            return;
        }
        Player1Score++;
        Player1ScoreText.text = Player1Score.ToString();
        P1PartyPopper.Pop();
        MyCameraShaker.Shake();

        BroadcastMessage("OnScoreIncreased", new Vector2(Player1Score, 0));
        if (IsActive)
        {
            MyThingDisplayer.Go();
        }
    }

    public void OnPlayer2KeyPressed()
    {
        if (MyThingDisplayer.IsOnDisplay == false)
        {
            return;
        }
        Player2Score++;
        Player2ScoreText.text = Player2Score.ToString();
        P2PartyPopper.Pop();
        MyCameraShaker.Shake();

        BroadcastMessage("OnScoreIncreased", new Vector2(Player2Score, 1));
        if (IsActive)
        {
            MyThingDisplayer.Go();
        }
    }

    public void Stop()
    {
        IsActive = false;
    }

    public void Reset()
    {
        Player1Score = 0;
        Player2Score = 0;
        Player1ScoreText.text = "0";
        Player2ScoreText.text = "0";
        IsActive = true;
    }
}
