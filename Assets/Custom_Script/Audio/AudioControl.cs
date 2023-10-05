using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;


public class AudioControl : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject next;

    public GameObject play;

    public GameObject model;

    public RuntimeAnimatorController controller;

    float timer;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            timer += Time.deltaTime;

            if (timer >= audioSource.clip.length - 0.5f)
            {
                audioSource.Stop();

                next.SetActive(true);

                model.transform.GetComponent<Animator>().runtimeAnimatorController = controller;

                gameManager.audio_flag = true; // the audio is over to play
            }
        }
        else
        {
            play.transform.GetComponent<Interactable>().IsEnabled = true;
        }

        if (next.activeSelf && gameManager.audio_flag) // reset the timer, make the audio can play again
        {
            timer = 0;

            gameManager.audio_flag = false;
        }
    }

    public void AudioPause()
    {
        audioSource.Pause();

        Debug.Log("Pause guide audio");
    }
}
