using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyController : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    [SerializeField]
    float hp = 100;

    [SerializeField]
    int kills = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(-speed, 0) * Time.deltaTime;
        transform.Translate(movement);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 25;
        }
    }
}
