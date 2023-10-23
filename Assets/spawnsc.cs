using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsc : MonoBehaviour
{

    [SerializeField]
    float delay;

    [SerializeField]
    GameObject prefab;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            Instantiate(prefab, gameObject.transform);
            timer = 0;
        }
    }
}
