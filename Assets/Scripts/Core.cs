using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour {

    public GameObject youwin;
    public AudioClip levelup, explosion, damage, win, doubleup;
    AudioSource audioSource;
    AudioSource musicSource;
    // Use this for initialization
    void Start () {
        var sources = gameObject.GetComponents<AudioSource>();
        audioSource = sources[0];
        musicSource = sources[1];
        musicSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void PlaySound(int s)
    {
        switch (s)
        {
            case 1:
                audioSource.PlayOneShot(levelup, 0.5f);
                break;
            case 2:
                audioSource.PlayOneShot(explosion, 0.1f);
                break;
            case 3:
                audioSource.PlayOneShot(damage);
                break;
            case 4:
                audioSource.PlayOneShot(win, 0.1f);
                break;
            case 5:
                audioSource.PlayOneShot(doubleup, 0.6f);
                break;
            default:
                break;
        }
    }

    public void End()
    {
        Instantiate(youwin);
        Invoke("quit", 7f);
    }

    void quit()
    {
        SceneManager.LoadScene("menu");
    }
}
