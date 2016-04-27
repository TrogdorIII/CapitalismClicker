using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class MenuHandler : MonoBehaviour {

	public bool isTrumpMode;

	public AudioSource audio;
	public AudioClip register;

	public Text trumpModeBtn;
	public GameObject trumpParticles;
	public GameObject moneyParticles;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

	public void LoadScene()
	{
		audio.PlayOneShot (register);
		Application.LoadLevel (1);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void TrumpMode()
	{
		if (isTrumpMode == false) {
			isTrumpMode = true;
			trumpParticles.SetActive (true);
			moneyParticles.SetActive (false);
			trumpModeBtn.text = "Trump Mode: ON";
		} else {
			isTrumpMode = false;
			trumpParticles.SetActive (false);
			moneyParticles.SetActive (true);
			trumpModeBtn.text = "Trump Mode: OFF";
		}
	}
}