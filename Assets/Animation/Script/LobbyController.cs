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

    private void PlayGame()
    { 
        //SceneManager.LoadScene(1);s
        LevelSelection.SetActive(true);
    }

}
