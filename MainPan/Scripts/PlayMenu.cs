using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Analytics;

public class PlayMenu : MonoBehaviour {

    [SerializeField]
    public AudioSource ButtonClikSound;

    int levelsUnlocked;
    public Button [] buttons;
    //
    //public int CounterCansel = 0;
    public int Counter;
    [SerializeField]
    private string reward;
    [SerializeField]
    GameObject PauPan;
    //

    void Start()
    {
        levelsUnlocked = Progress.Instance.levelComplete + 1;
        //
        Counter = Progress.Instance.CounterPref;
        //
        for (int i = 1; i < buttons.Length; i++)
        {
            if(i + 1 > levelsUnlocked)
                buttons[i].interactable = false;
        }
    }

    void Update()
    {
        Progress.Instance.CounterPref = Counter;
    }

    public void Continue()
    {
        SceneManager.LoadScene(Progress.Instance.levelComplete +1);
        //GameDistribution.Instance.ShowAd();
        GameAnalytics.gameAnalytics.InterstitialAd();
    }

    public void PreRoll()
    {
        //GameDistribution.Instance.ShowAd();
        Debug.Log("PreRollPlay!");
        GameAnalytics.gameAnalytics.InterstitialAd();
    }

    public void TryAgain()
    {
        //Counter++;
        Progress.Instance.CounterSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        //GameDistribution.Instance.ShowAd();
        GameAnalytics.gameAnalytics.InterstitialAd();
    }

    public void CanselRewardDelSave()
    {
        DelSave();
        Counter = 2;
        Progress.Instance.CounterSave();
        Play1();
    }

    
    public void RewardedLive()
    {
        //
        Counter = 3;
        Progress.Instance.CounterPref = 3;
        Progress.Instance.CounterSave();
        PauPan.gameObject.SetActive(false);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        //
        //GameDistribution.Instance.ShowRewardedAd();
        Debug.Log("ADR1!");
        GameAnalytics.gameAnalytics.RewardedAd();
    }


    public void LoadMain()
    {
        Progress.Instance.EndLevel();
        Progress.Instance.CounterSave();
        SceneManager.LoadScene("0");
        Time.timeScale = 1f;
    }
    public void DelSave()
    {
        Progress.Instance.DeleteSave();
        SceneManager.LoadScene("0");
        Time.timeScale = 1f;
    }

    public void Play1()
    {
        SceneManager.LoadScene("1");
        Time.timeScale = 1f;
    }

    public void Play2()
    {
        SceneManager.LoadScene("2");
        Time.timeScale = 1f;
    }

    public void Play3()
    {
        SceneManager.LoadScene("3");
        Time.timeScale = 1f;
    }
        
    public void Play4()
    {
        SceneManager.LoadScene("4");
        Time.timeScale = 1f;
    }

    public void Play5()
    {
        SceneManager.LoadScene("5");
        Time.timeScale = 1f;
    }

    public void Play6()
    {
        SceneManager.LoadScene("6");
        Time.timeScale = 1f;
    }

    public void Play7()
    {
        SceneManager.LoadScene("7");
        Time.timeScale = 1f;
    }

    public void Play8()
    {
        SceneManager.LoadScene("8");
        Time.timeScale = 1f;
    }

    public void Play9()
    {
        SceneManager.LoadScene("9");
        Time.timeScale = 1f;
    }

    public void Play10()
    {
        SceneManager.LoadScene("10");
        Time.timeScale = 1f;
    }

    public void Play11()
    {
        SceneManager.LoadScene("11");
        Time.timeScale = 1f;
    }

    public void Play12()
    {
        SceneManager.LoadScene("12");
        Time.timeScale = 1f;
    }

    public void Play13()
    {//Last
        SceneManager.LoadScene("13");
        Time.timeScale = 1f;
    }
}
