using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour
{

    public bool isTrumpMode;

    public AudioSource audio;
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
        Application.LoadLevel(1);
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
}