using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopBallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody.velocity = new Vector2(Random.Range(-4f, 4f), Random.Range(4f, 8f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            int random = Random.Range(1, 9);
            Destroy(collision.gameObject);
            BallControl.blocks++;
        }

    }
}
