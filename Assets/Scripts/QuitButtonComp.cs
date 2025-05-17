using UnityEngine;

public class QuitButtonComp : MonoBehaviour
{
    public void OnPressQuitButton()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
