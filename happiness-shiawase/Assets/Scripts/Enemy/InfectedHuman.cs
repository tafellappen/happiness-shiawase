using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHuman : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float secondsBetweenSpawn;

    float spawnTimer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // https://answers.unity.com/questions/1331151/c-need-help-making-an-enemy-spawn-timer.html
        spawnTimer += Time.deltaTime;

        if (spawnTimer > secondsBetweenSpawn)
        {
            spawnTimer = 0;
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

}
