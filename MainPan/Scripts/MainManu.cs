using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour {

	public void QuitGame(){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}

	[SerializeField]
	public AudioSource ButtonClikSound;

	[SerializeField]
	GameObject PausePan;
	[SerializeField]
	GameObject BtnMusicON;
	[SerializeField]
	GameObject BtnMusicOFF;
	[SerializeField]
	GameObject BtnSfxON;
	[SerializeField]
	GameObject BtnSfxOFF;
	public UnityEngine.Audio.AudioMixerGroup Mixer;
	[SerializeField]
	public int MusicMuteMain;
	[SerializeField]
	public int SoundMuteMain;

	private void OnEnable()
	{
		Time.timeScale = 1;
	}

	private void OnDisable()
	{
		Time.timeScale = 1;
	}

	public void PausePanelON()
	{
		PausePan.gameObject.SetActive(true);
		ButtonClikSound.Play();
	}

	public void PausePanelOFF()
	{
		PausePan.gameObject.SetActive(false);
		ButtonClikSound.Play();
	}
	
	void Start()
    {
		MusicMuteMain = Progress.Instance.MusicMute;
		SoundMuteMain = Progress.Instance.SoundMute;
		if (MusicMuteMain == 0)
		{
			BtnMusicON.gameObject.SetActive(false);
			BtnMusicOFF.gameObject.SetActive(true);

		}
		if(MusicMuteMain == 1)
        {
			BtnMusicON.gameObject.SetActive(true);
			BtnMusicOFF.gameObject.SetActive(false);
		}
        if (SoundMuteMain == 0)
        {
			BtnSfxON.gameObject.SetActive(false);
			BtnSfxOFF.gameObject.SetActive(true);
		}
		if (SoundMuteMain == 1)
		{
			BtnSfxON.gameObject.SetActive(true);
			BtnSfxOFF.gameObject.SetActive(false);
		}
	}

	void Update()
    {

    }
	public void MusicON()
	{
		Mixer.audioMixer.SetFloat("MusicVolume", -80);
		BtnMusicON.gameObject.SetActive(false);
		BtnMusicOFF.gameObject.SetActive(true);
		ButtonClikSound.Play();
		MusicMuteMain = 0;
		Progress.Instance.MusicMute = MusicMuteMain;
		Progress.Instance.MusicSoundSave();
	}

	public void MusicOFF()
	{
		Mixer.audioMixer.SetFloat("MusicVolume", -5);
		BtnMusicON.gameObject.SetActive(true);
		BtnMusicOFF.gameObject.SetActive(false);
		ButtonClikSound.Play();
		MusicMuteMain = 1;
		Progress.Instance.MusicMute = MusicMuteMain;
		Progress.Instance.MusicSoundSave();
	}
	public void SfxON()
	{

		Mixer.audioMixer.SetFloat("EffectVolume", -80);
		BtnSfxON.gameObject.SetActive(false);
		BtnSfxOFF.gameObject.SetActive(true);
		ButtonClikSound.Play();
		SoundMuteMain = 0;
		Progress.Instance.SoundMute = SoundMuteMain;
		Progress.Instance.MusicSoundSave();
	}
	public void SfxOFF()
	{
		Mixer.audioMixer.SetFloat("EffectVolume", -0);
		BtnSfxON.gameObject.SetActive(true);
		BtnSfxOFF.gameObject.SetActive(false);
		ButtonClikSound.Play();
		SoundMuteMain = 1;
		Progress.Instance.SoundMute = SoundMuteMain;
		Progress.Instance.MusicSoundSave();
	}
	public void RateUs()
    {
		//YandexSDK.YaSDK.instance.OpenRateUsWindow();
	}
}
