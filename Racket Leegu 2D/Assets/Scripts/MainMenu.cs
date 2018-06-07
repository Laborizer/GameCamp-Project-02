using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    AudioSource audiosource;
    public AudioClip HoverSound;
    public AudioClip ClickSound;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        audiosource.PlayOneShot(ClickSound, 0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitgame()
    {
        audiosource.PlayOneShot(ClickSound, 0.8f);
        Application.Quit();
    }

    private void OnMouseEnter()
    {
        audiosource.PlayOneShot(HoverSound, 0.8f);
    }
}
