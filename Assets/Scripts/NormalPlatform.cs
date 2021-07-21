using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NormalPlatform : MonoBehaviour
{
    public float forceJump = 9f;
    private Rigidbody2D DudeRigid;
    public GameObject player;
    public AudioSource music;
    public void Start()
    {
        // получение rigidBody игрока
        player = GameObject.Find("Character");
        DudeRigid = player.GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            DudeRigid.velocity = Vector2.up * forceJump;
            music.Play();
        }

        if (collision.collider.name == "DeadZone")
        {
            Destroy(gameObject);
            GeneratePlatform.count -= 1;
        }
    }
}
