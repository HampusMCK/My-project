using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSc : MonoBehaviour //Bullet controller script
{

    Rigidbody2D rb;
    [SerializeField]
    Vector2 power = new(300, 0);

    float timer = 0;

    static public decimal upgradePrice = 12;

    static public float damage = 12.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(power);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }

    public void upgradeGun()
    {
        playerController.cash -= upgradePrice;
        if (playerController.cash < 0)
        {
            playerController.cash += upgradePrice;
        }
        else
        {
            damage *= 1.2f;
            upgradePrice *= (decimal)1.5;
            upgradePrice = decimal.Round(upgradePrice, 1, MidpointRounding.AwayFromZero);
        }
    }
}
