using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

   public Button buttonRestart;
   public Button buttonQuit;  
   public Button buttonMainMenu;

   private void Awake()
   {
      buttonRestart.onClick.AddListener(ReloadLevel); 
      buttonQuit.onClick.AddListener(quitGame);    
      buttonMainMenu.onClick.AddListener(mainMenu);
   }
   public void PlayerDied()
   {
      gameObject.SetActive(true);
   }

   public void ReloadLevel()
   {
      Debug.Log("Reload Scene 0");
      SceneManager.LoadScene(1); 
   }

   private void quitGame()
   {
      UnityEditor.EditorApplication.isPlaying = false; 
   }
   private void mainMenu()
   {
      SceneManager.LoadScene(0);
   }
}