using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSc : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    Vector2 power = new(300, 0);

    float timer = 0;

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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
