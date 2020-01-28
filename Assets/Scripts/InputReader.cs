using UnityEngine;

public class InputReader : MonoBehaviour
{
    public KeyCode Player1Key;
    public KeyCode Player2Key;

    private bool IsActive = true;

    public void Go()
    {
        IsActive = true;
    }
    
    public void Stop()
    {
        IsActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsActive == false)
        {
            return;
        }
        if (Input.GetKeyDown(Player1Key))
        {
            BroadcastMessage("OnPlayer1KeyPressed");
        }
        
        if (Input.GetKeyDown(Player2Key))
        {
            BroadcastMessage("OnPlayer2KeyPressed");
        }
    }
}
