using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour
{

    public bool isTrumpMode;

    public AudioSource audio;
    public GameObject music;
    public AudioClip register;

    public Text trumpModeBtn;
    public Material trump;
    public Material money;
    public GameObject moneyParticle;
    private ParticleSystemRenderer particleRenderer;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        particleRenderer = moneyParticle.GetComponent<ParticleSystemRenderer>();
    }

    public void LoadScene()
    {
        audio.PlayOneShot(register);
        music.SetActive(false);
        StartCoroutine(WaitToLoad());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TrumpMode()
    {
        if (isTrumpMode == false)
        {
            isTrumpMode = true;
            particleRenderer.material = trump;
            trumpModeBtn.text = "Trump Mode: ON";
        }
        else {
            isTrumpMode = false;
            particleRenderer.material = money;
            trumpModeBtn.text = "Trump Mode: OFF";

        }
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(1);
    }
}