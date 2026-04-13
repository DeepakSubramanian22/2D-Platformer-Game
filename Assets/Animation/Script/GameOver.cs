using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

   public Button buttonRestart;

   private void Awake()
   {
      buttonRestart.onClick.AddListener(ReloadLevel);
   }
   public void PlayerDied()
   {
      gameObject.SetActive(true);
   }

   private void ReloadLevel()
   {
      Debug.Log("Reload Scene 0");
      SceneManager.LoadScene(0); 
   }
}
