using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField]
    [Range(10f, 100f)]
    float speed = 20f;
    [SerializeField]
    private TextMeshProUGUI liveText;
    [SerializeField]
    private GameObject ball;
    public static float distanse = 0.5f;

    void FixedUpdate()
    {
        HandleTouchInput();
        ComputerMuving();
        liveText.text = BallControl.lives.ToString();
    }

    private void HandleTouchInput()
    {
        speed = 100f;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Moved) 
            {
                float moveInput = touch.deltaPosition.x / Screen.width * speed;
                transform.Translate(moveInput * Time.deltaTime * Vector3.right);
                transform.position = new Vector2(
                    Mathf.Clamp(transform.position.x, -1.7f, 1.7f),
                    transform.position.y
                );
            }
        }
    }

    private void ComputerMuving()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.7f, 1.7f), transform.position.y);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Live"))
        {
            Destroy(collision.gameObject);
            BallControl.lives++;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            Speed();
        }
    }

    IEnumerator Ball()
    {
        Instantiate(ball);
        ball.transform.position =  new Vector2(this.transform.position.x, this.transform.position.y + 5f);
        yield return new WaitForSeconds(2f);
        Destroy(ball);
    }

    private void Speed()
    {
        rigidbody.velocity = new Vector2(Random.Range(-4f, 4f), Random.Range(4f, 8f));
    }
}
