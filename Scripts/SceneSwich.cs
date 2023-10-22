using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Analytics;

public class SceneSwich : MonoBehaviour {

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
		StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex +1));
		//Progress.Instance.playerInfo.Level = SceneManager.GetActiveScene().buildIndex;
		//Save Del if problem
		Progress.Instance.level = SceneManager.GetActiveScene().buildIndex;
		//PlayerPrefs.Save();
		Progress.Instance.EndLevel();
		//
		GameAnalytics.gameAnalytics.LogEvent("Level Up");
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
