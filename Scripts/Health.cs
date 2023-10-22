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
    //
    public int CounterHealth;
    [SerializeField]
    private Text counterText;
    [SerializeField]
    GameObject PauPan;
    //

    void Start()
    {
        health = Progress.Instance.numHearts;
        //
        CounterHealth = Progress.Instance.CounterPref;
        //
    }
    void Update()
    {
        Progress.Instance.numHearts = health;
        //
        Progress.Instance.CounterPref = CounterHealth;
        //
        if (health > numOfHearts)
        {

            //old workable
            health = numOfHearts;
        }
        if (health <= 0)
        {

            //Old workable
            //health = 0;
            CounterHealth -= 1;
            Progress.Instance.CounterPref = CounterHealth;
            Progress.Instance.CounterSave();
            health = 3;
            Progress.Instance.NumHeartsSave();
            //
            GetComponent<CactusController>().enabled = false;
            DeathUI.gameObject.SetActive(true);
            //health = 3;
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
        //
        counterText.text = null;
        counterText.text = "lifes:" + CounterHealth;
        if (CounterHealth <= 0)
        {
            CounterHealth = 3;
            health = 3;
            Progress.Instance.NumHeartsSave();
            Progress.Instance.CounterPref = CounterHealth;
            Progress.Instance.CounterSave();
            PauPan.gameObject.SetActive(true);
            GetComponent<CactusController>().enabled = false;
            //DeathUI.gameObject.SetActive(true);
        }
        //
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
            health -= 1;
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