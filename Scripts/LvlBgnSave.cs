using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlBgnSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AudioListener.pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        // (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse2))
        /*if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.D))
        {
            AudioListener.pause = false;
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Progress.Instance.EndLevel();
        }
    }
}
