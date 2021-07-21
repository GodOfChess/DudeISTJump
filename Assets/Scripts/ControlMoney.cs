using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMoney : MonoBehaviour
{
    private AudioSource music;
    private void Start()
    {
        music = GameObject.Find("MusicMoney").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            music.Play();
            Destroy(gameObject);
            ControlScore.score += 5;
        }
    }
}
