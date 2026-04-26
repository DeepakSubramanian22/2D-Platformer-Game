using UnityEngine;

public class SoundManager : MonoBehaviour
{
      private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundType[] sounds; 

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
    
    

public enum Sounds 
{
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}