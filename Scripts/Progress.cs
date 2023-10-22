using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerInfo
{
    //public int NumOfHearts;
    //public int Level;
}

public class Progress : MonoBehaviour
{
    public static Progress Instance = null;

    [SerializeField]
    public int numHearts;
    [SerializeField]
    public int level;
    [SerializeField]
    public int levelComplete;
    [SerializeField]
    public int MusicMute;
    [SerializeField]
    public int SoundMute;
    //
    [SerializeField]
    public int CounterPref;
    //

    private void Awake()
    {
        //levelComplete = PlayerPrefs.GetInt("levelComplete");
        //MusicMute = PlayerPrefs.GetInt("MusicMute");
        //SoundMute = PlayerPrefs.GetInt("SoundMute");        
        //level = SceneManager.GetActiveScene().buildIndex;
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            if (PlayerPrefs.HasKey("NumHearts")) numHearts = PlayerPrefs.GetInt("NumHearts");
            if (PlayerPrefs.HasKey("levelComplete")) levelComplete = PlayerPrefs.GetInt("levelComplete");
            if (PlayerPrefs.HasKey("MusicMute")) MusicMute = 1;//PlayerPrefs.GetInt("MusicMute");
            if (PlayerPrefs.HasKey("SoundMute")) SoundMute = 1;//PlayerPrefs.GetInt("SoundMute");
            if (PlayerPrefs.HasKey("Level")) level = PlayerPrefs.GetInt("Level");
            if (PlayerPrefs.HasKey("CounterPref")) CounterPref = 2; //PlayerPrefs.GetInt("CounterPref");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("levelComplete");
    }
    public void EndLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex +1;
        PlayerPrefs.SetInt("NumHearts", numHearts);
        //PlayerPrefs.SetInt("Level", level);
        if(levelComplete < level)
            PlayerPrefs.SetInt("levelComplete", level-1);
    }
    public void MusicSoundSave()
    {
        PlayerPrefs.SetInt("MusicMute", MusicMute);
        PlayerPrefs.SetInt("SoundMute", SoundMute);
    }

    public void CounterSave()
    {
        PlayerPrefs.SetInt("CounterPref", CounterPref);
    }

    public void NumHeartsSave()
    {
        PlayerPrefs.SetInt("NumHearts", numHearts);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    /*
    void Start()
    {
        if (PlayerPrefs.HasKey("NumOfHearts")) numOfHearts = PlayerPrefs.GetInt("NumOfHearts");
        if (PlayerPrefs.HasKey("Level")) level = PlayerPrefs.GetInt("Level");
    }
    
    void Update()
    {
        if ()
        {
            PlayerPrefs.SetInt("NumOfHearts", numOfHearts);
            PlayerPrefs.SetInt("Level", level);
        }
    }*/
    /*
    public static Progress Instance;

    private void Awake()
    {

        if(Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
}
