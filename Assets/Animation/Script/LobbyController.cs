using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button Buttonplay;
    public Button ButtonQuit;

    private void Awake()
    {
        Buttonplay.onClick.AddListener(PlayGame);
        ButtonQuit.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; 
    }

}
