using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    [Range(10f, 100f)]
    float speed = 20f;
    [SerializeField]
    private TextMeshProUGUI liveText;
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
    }
}
