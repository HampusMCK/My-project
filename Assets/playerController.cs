using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    int speed = 5;

    Rigidbody2D rBody;

    void Awake()
  {
    rBody = GetComponent<Rigidbody2D>();
  }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveX, 0) * speed;
        transform.Translate(movement);
        bool isGrounded = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);
        if (isGrounded && Input.GetAxisRaw("Jump") > 0)
        {
            rBody.AddForce(Vector2.up*5);
        }
    }

    private Vector2 GetFootPosition()
  {
    float height = GetComponent<Collider2D>().bounds.size.y;
    return transform.position + Vector3.down * height / 2;
  }

  private Vector2 GetFootSize()
  {
    return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
  }
}
