/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    
    [SerializeField]
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    [SerializeField]
    GameObject DeathUI;
    [SerializeField]
    GameObject AddHeart;
    [SerializeField]
    private AudioSource knockbackSound;
    [SerializeField]
    private AudioSource HeartSounds;
    [SerializeField]
    private AudioSource gameoverSounds;

    void Start()
    {
        health = Progress.Instance.numHearts;
    }
    void Update()
    {
        // Save Del if problem
        Progress.Instance.numHearts = health;

        //
        if (health > numOfHearts)
        {

            //old workable
            health = numOfHearts;
        }
        if (health <= 0)
        {
            health = 3;
            //Old workable
            //health = 0;
            GetComponent<CactusController>().enabled = false;
            DeathUI.gameObject.SetActive(true);
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Saw")
        {
            health -= 1;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "DethZone")
        {
            health -= 5;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "Spike")
        {
            health -= 1;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "AddHeart")
        {
            health += 1;
            AddHeart.SetActive(false);
            HeartSounds.Play();
            //DestroyObject(AddHeart);
        }
    }

}
////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField]
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    [SerializeField]
    GameObject DeathUI;
    [SerializeField]
    GameObject AddHeart;
    [SerializeField]
    private AudioSource knockbackSound;
    [SerializeField]
    private AudioSource HeartSounds;
    [SerializeField]
    private AudioSource gameoverSounds;

    public int CounterCansel = 0;
    public int Counter = 0;
    [SerializeField]
    private Text counterText;
    [SerializeField]
    private string reward;

    void Start()
    {
        
        health = Progress.Instance.numHearts;
        Counter = 2;
        counterText.text = null;
    }
    void Update()
    {
        
        
        
        // Save Del if problem
        Progress.Instance.numHearts = health;
        
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (health <= 0)
        {
            
            //Old workable
            //health = 0;
            GetComponent<CactusController>().enabled = false;
            DeathUI.gameObject.SetActive(true);
            //
            Counter--;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Time.timeScale = 1f;
            //
            health = 3;
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //counter of lives
        counterText.text = "Жизни:" + Counter;
        if (Counter <= -1)
        {
            Counter = 0;
            //PauPan.gameObject.SetActive(true);
            GetComponent<CactusController>().enabled = false;
            DeathUI.gameObject.SetActive(true);
        }

    }
    public void CanselAd()
    {
        Counter = +1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        CounterCansel++;
        CanselCount();
        //PauPan.gameObject.SetActive(false);
        //ButtonClikSound.Play();
    }
    private void OnEnable()
    {
        YandexSDK.YaSDK.onRewardedAdReward += UserGotReward;
    }
    private void OnDisable()
    {
        YandexSDK.YaSDK.onRewardedAdReward -= UserGotReward;
    }
    public void ShowRewarded()
    {
        YandexSDK.YaSDK.instance.ShowRewarded(reward);
    }
    public void UserGotReward(string reward)
    {
        if (this.reward == reward)
        {
            //ButtonClikSound.Play();
            Counter = +3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
            //PauPan.gameObject.SetActive(false);
            Debug.Log("ADR1!");
        }
    }
    public void CanselCount()
    {
        if (CounterCansel == 3)
        {
            YandexSDK.YaSDK.instance.OpenRateUsWindow();
            Debug.Log("RateUs3!");
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Saw")
        {
            health -= 1;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "DethZone")
        {
            health -= 5;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "Spike")
        {
            health -= 1;
            knockbackSound.Play();
        }

        if (col.gameObject.tag == "AddHeart")
        {
            health += 1;
            AddHeart.SetActive(false);
            HeartSounds.Play();
            //DestroyObject(AddHeart);
        }
    }

}





////////

*/

