using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundlayer;

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
        bool isGrounded()
        {
            if (
                
            )
            return false;
        }
    }
}
