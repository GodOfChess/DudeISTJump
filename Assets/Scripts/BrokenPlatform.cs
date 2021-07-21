using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    private AudioSource music;
    private Rigidbody2D DudeRigid;
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Character");
        music = GameObject.Find("MusicBroken").GetComponent<AudioSource>();
        DudeRigid = player.GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            DudeRigid.velocity = new Vector2(0, -4f);
            music.Play();
            Destroy(gameObject);
            GeneratePlatform.brokencount -= 1;
        }

        if (collision.collider.name == "DeadZone")
        {
            Destroy(gameObject);
            GeneratePlatform.brokencount -= 1;
        }
    }
}
