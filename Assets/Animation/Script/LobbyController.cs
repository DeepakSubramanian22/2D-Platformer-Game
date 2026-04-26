using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button Buttonplay;
    public GameObject LevelSelection; 

    private void Awake()
    {
        Buttonplay.onClick.AddListener(PlayGame);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("ShowLevelSelect", 0) == 1)
        {
            PlayerPrefs.SetInt("ShowLevelSelect", 0);
            LevelSelection.SetActive(true);  // came from Game Over
        }
        else
        {
            LevelSelection.SetActive(false); // normal launch
        }
    }
    
    private void PlayGame()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick); // ✓ fixed
        LevelSelection.SetActive(true);
    }

}
