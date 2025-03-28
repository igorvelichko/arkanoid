using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject live;
    [SerializeField] private GameObject ball;
    public static int lives = 1;
    public static int blocks = 0;

    private void Start()
    {
        rigidbody.velocity = new Vector2(Random.Range(-4f, 4f), Random.Range(4f,8f));
        lives = 1;
        blocks = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loze"))
        {
            lives--;
            if (lives < 1)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
            
        if (collision.gameObject.CompareTag("Block"))
        {
            int random = Random.Range(1, 9);
            Destroy(collision.gameObject);
            blocks++;
            if(blocks == 35)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
            if(random == 5)
            {
                Instantiate(live);
                live.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
            }
            if (random == 7)
            {
                Instantiate(ball);
                ball.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
            }
        }
    }


}
