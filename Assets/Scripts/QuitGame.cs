using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// Quit the game
    /// </summary>
    /// <param name="value">Object containing Callback Context</param>
    public void OnQuitGame(InputAction.CallbackContext value)
    {
        Application.Quit();
    }
}
