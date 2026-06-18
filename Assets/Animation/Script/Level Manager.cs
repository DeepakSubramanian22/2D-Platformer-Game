using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string [] Level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    private void Start()
    {
        if (GetLevelStatus(Level[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Level[0] , LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        
        //int nextSceneIndex = currentScene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneAt(nextSceneIndex);
        //Debug.Log("Next scene is valid:" + nextScene.IsValid());
        //SetLevelStatus(nextScene.name , LevelStatus.Unlocked);
        
        int currentSceneindex = Array.FindIndex(Level, level => level == currentScene.name);
        int nextSceneindex = currentSceneindex + 1;
        if(nextSceneindex < Level.Length)
        {
            SetLevelStatus(Level[nextSceneindex], LevelStatus.Unlocked); 
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level , 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level , (int)levelStatus);
    }
}
 