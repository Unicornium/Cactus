using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoop : MonoBehaviour
{

	public Animator transition;

	public float transitionTime = 1f;

	void OnTriggerEnter2D(Collider2D Other)
	{
		//GameDistribution.Instance.ShowAd();
		Debug.Log("NextLvlInterstetial!");
		LoadNextLevel();
	}

	public void LoadNextLevel()
	{
		StartCoroutine(loadLevel(4));
		//Progress.Instance.playerInfo.Level = SceneManager.GetActiveScene().buildIndex;
		//Save Del if problem
		Progress.Instance.level = SceneManager.GetActiveScene().buildIndex;
		//PlayerPrefs.Save();
		Progress.Instance.EndLevel();
		//
	}

	IEnumerator loadLevel(int levelIndex)
	{
		//Play animation
		transition.SetTrigger("Start");
		//Wait
		yield return new WaitForSeconds(transitionTime);
		//Load scene
		SceneManager.LoadScene(levelIndex);
	}
}
