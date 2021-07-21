using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScore : MonoBehaviour
{
    private float currentY;
    public GameObject player;
    public Text scoretext;
    public static int score = 0;
    private void Start()
    {
        player = GameObject.Find("Character");
        currentY = player.transform.position.y;
        scoretext = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        scoretext.text = $"Score: {score}";
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Round(currentY) != Mathf.Round(player.transform.position.y))
        {
            if (collision.relativeVelocity.y < 0)
            {
                if (collision.otherCollider.tag == "Boost")
                {
                    score += 3;
                }
                else
                {
                    score += 1;
                }
                currentY = player.transform.position.y;
            }
        }
    }
}
