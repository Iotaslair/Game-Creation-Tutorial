﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlackScript : MonoBehaviour {

    private bool resetNow = false;
    private bool first = true;
    //resetting the level
    public AudioSource GameRestartFX;
    public AudioClip restartLevel;
    //fade to black
    public Animator blackAnimator;
    public Image blackImage;

    public AudioSource cloneSoundSource;

    // Update is called once per frame
    void Update () {
        fadeToBlack();
	}

    public void startFadeToBlack()
    {
        resetNow = true;
    }

    private void fadeToBlack()
    {
        if (resetNow)
        {
            if (!GameRestartFX.isPlaying && !first)
            {
                print("turning off FadeOut");
                blackAnimator.SetBool("FadeOut", false);
                resetNow = false;
                print("resetting the level");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (first)
            {
                GameRestartFX.clip = restartLevel;
                GameRestartFX.Play();
                cloneSoundSource.Stop();
                print("Turning on FadeOut");
                blackAnimator.SetBool("FadeOut", true);
                first = false;
            }            
        }
    }
}
