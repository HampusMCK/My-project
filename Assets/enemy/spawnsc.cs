using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsc : MonoBehaviour//Spawn enemies script
{

    [SerializeField]
    float delay;

    [SerializeField]
    GameObject zombie, zombie1;

    static public int wave = 1;
    static public int spawn = 5;
    int i = 0; //Enemies currently spawned

    float timer = 2;

    // Update is called once per frame
    void Update()
    {
        if (i < spawn)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                if (wave > 2)
                {
                    int spawnChance = 12 - wave;
                    int s = Random.Range(1, spawnChance);
                    if (s == spawnChance - 1)
                    {
                        Instantiate(zombie1, gameObject.transform);
                    }
                    else
                    {
                        Instantiate(zombie, gameObject.transform);
                    }
                }
                else
                {
                    Instantiate(zombie, gameObject.transform);
                }
                timer = 0;
                i++;
            }
        }
    }

    public void startWave()
    {
        wave++;
        spawn = 5 * wave;
        i = 0;
        delay *= 0.8f;
    }
}
