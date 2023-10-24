using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsc : MonoBehaviour
{

    [SerializeField]
    float delay;

    [SerializeField]
    GameObject prefab;

    public bool inWave = true;

    int wave = 0;
    int spawn = 5;
    int i = 0;

    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inWave && i <= spawn)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                Instantiate(prefab, gameObject.transform);
                timer = 0;
                i++;
            }
        }
    }
}
