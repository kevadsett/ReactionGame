using UnityEngine;
using UnityEngine.UI;

public class WinnerDecider : MonoBehaviour
{
    public ThingDisplayer MyThingDisplayer;
    public InputReader MyInputReader;
    public ScoreGiver MyScoreGiver;
    public GameResetter MyGameResetter;
    public Text ResultText;
    public int RequiredScoreToWin = 5;

    void Start()
    {
        ResultText.gameObject.SetActive(false);
    }

    public void OnScoreIncreased(Vector2 CurrentScore)
    {
        if (CurrentScore.x == RequiredScoreToWin)
        {
            ResultText.text = "PLAYER " + (CurrentScore.y + 1) + " WINS!";
            ResultText.gameObject.SetActive(true);
            MyThingDisplayer.Stop();
            MyInputReader.Stop();
            MyScoreGiver.Stop();
            MyGameResetter.SetIsActive();
        }
    }
}
