using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    int speed = 5;

    [SerializeField]
    int jumpForce = 50;

    [SerializeField]
    float groundRadius = 0.2f;

    [SerializeField]
    Transform nuzzle;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float timeBetweenShots = 2;

    [SerializeField]
    Slider healthSlider;

    float health = 100;

    float timer = 2;
    float t = 1;

    bool looking;

    Rigidbody2D rBody;
    bool hasReleasedJumpButton = true;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

        if (looking)
        {
            transform.Translate(movement);
        }
        else
        {
            transform.Translate(-movement);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            looking = true;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            looking = false;
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        timer += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") > 0 && timer >= timeBetweenShots && looking)
        {
            Instantiate(bulletPrefab, nuzzle.position, transform.rotation);
            timer = 0;
        }

        bool isGrounded = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);

        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton && isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" && t > 1.5f)
        {
            health -= 10;
            updateHealthSlider();
            t = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" && t > 1.5f)
        {
            health -= 10;
            updateHealthSlider();
            t = 0;
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

    private void updateHealthSlider()
    {
        healthSlider.value = health;
    }
}
