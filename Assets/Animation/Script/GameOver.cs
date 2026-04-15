using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
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

   public void ReloadLevel()
   {
      Debug.Log("Reload Scene 0");
      SceneManager.LoadScene(1); 
   }
}