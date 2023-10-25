using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyController : MonoBehaviour //Enemy controller and kill counter
{

    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    [SerializeField]
    float hp = 100;

    [SerializeField]
    int minStart, minIncrease, maxStart, maxIncrease;


    static public int kills = 0;

    // Update is called once per frame
    void Update()
    {
        int minEarn = minStart + (minIncrease * (spawnsc.wave - 1));
        int maxEarn = maxStart + (maxIncrease * (spawnsc.wave - 1));

        Vector2 movement = new Vector2(-speed, 0) * Time.deltaTime;
        transform.Translate(movement);

        if (hp <= 0)
        {
            Destroy(gameObject);
            kills++;
            playerController.cash += Random.Range(minEarn, maxEarn);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= bulletSc.damage;
        }
    }

    public void newWave()
    {
        kills = 0;
    }
}
