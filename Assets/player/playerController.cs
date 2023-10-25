using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour//Player and game controller script
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
    float timeBetweenShots;

    [SerializeField]
    Slider healthSlider;

    static public float cash;

    static public float health = 100;

    static public float healPrice = (100 - health) * 2;

    float timer = 2; //Timer for shooting
    float t = 1; //Timer for taking damage from enemies

    static public bool wave = true; //Bool for if in wave or between

    bool looking = true; //Bool to see if player is looking right

    Rigidbody2D rBody;
    bool hasReleasedJumpButton = true;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healPrice = (100 - health) * 2;
        if (wave) //Check if wave active to be able to play
        {
            t += Time.deltaTime;

            float moveX = Input.GetAxisRaw("Horizontal");

            Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

            if (looking)
            {
                transform.Translate(movement);
            }
            else //Make movement negative if player rotated
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
            if ((Input.GetAxisRaw("Fire1") > 0 || Input.GetKeyDown(KeyCode.P)) && timer >= timeBetweenShots && looking) //Only shoot when looking right
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

        if (enemyController.kills == spawnsc.spawn) //Check if wave is completed
        {
            wave = false;
        }
        else
        {
            wave = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//take damage if enemy collides
    {
        if (other.gameObject.tag == "enemy" && t > 1.5f)
        {
            health -= 10;
            updateHealthSlider();
            t = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other) //Take damage every 1.5 seconds if enemy stays in contact
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

    public void Heal()
    {
        if (cash - healPrice >= 0)
        {
            cash -= healPrice;
            health = 100;
            updateHealthSlider();
        }
    }
}
