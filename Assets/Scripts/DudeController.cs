using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DudeController : MonoBehaviour
{
    private float horizontal;
    private float hor;
    private int record;
    public Rigidbody2D DudeRigid;
    private float speed = 10f;

    private void FixedUpdate()
    {
        // проверка на андроид
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        // если телефон наклонен, то вращаем спрайт
        if (horizontal <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        //изменение скорости при наклоне телефона
        DudeRigid.velocity = new Vector2(horizontal * speed, DudeRigid.velocity.y);

        //движение кнопками
        hor = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;
        pos.x += 3f * hor * Time.deltaTime;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            SceneManager.LoadScene(0);
            GeneratePlatform.count = 0;
            GeneratePlatform.brokencount = 0;
            if (ControlScore.score > record)
            {
                record = ControlScore.score;
                PlayerPrefs.SetInt("record", record);
            }
            ControlScore.score = 0;
        }
    }

    private void Start()
    {
        record = PlayerPrefs.GetInt("record");
    }
}
