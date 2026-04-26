using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;   
    public LevelStatus LevelStatus;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
    
        switch (levelStatus)                 // ✓ lowercase — correct variable
        {
            case LevelStatus.Locked:
                Debug.Log("Cant play this level , It is locked");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);  // ✓ only load when unlocked
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);  // ✓ allow replay
                break;
        }
    }
}
