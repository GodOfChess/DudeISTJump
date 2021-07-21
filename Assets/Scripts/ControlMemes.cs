using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMemes : MonoBehaviour
{
    public GameObject memeScore;
    private AudioSource music;
    public Animator memeControl;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (ControlScore.score != 0 && ControlScore.score % 100 == 0)
        {
            StartCoroutine(ShowMeme());
        }
    }

    private IEnumerator ShowMeme()
    {
        music.Play();
        memeControl.SetInteger("MemeControl", 1);
        yield return new WaitForSeconds(13f);
        memeControl.SetInteger("MemeControl", 0);
    }
}
