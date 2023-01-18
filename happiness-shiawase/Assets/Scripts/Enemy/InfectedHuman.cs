using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHuman : MonoBehaviour
{

    [SerializeField] GameObject virus;
    [SerializeField] float secondsBetweenSpawn;

    [SerializeField] float sprayTimer;
    [SerializeField] float infectDistance = 15;

    [SerializeField] Player player;

    float spawnTimer;

    
    bool cured;


    // Start is called before the first frame update
    void Start()
    {
        cured = false;
    }

    // Update is called once per frame
    void Update()
    {
        var pos1 = transform.position;
        var playerController = GameObject.FindGameObjectWithTag("Player");
        var pos2 = playerController.transform.position;

        var distance = Vector3.Distance(pos1, pos2);
        if (distance < infectDistance) {
            SpawnVirus();
        }
       
    }

    void SpawnVirus()
    {
        if (!cured)
        {
            // https://answers.unity.com/questions/1331151/c-need-help-making-an-enemy-spawn-timer.html
            spawnTimer += Time.deltaTime;

            if (spawnTimer > secondsBetweenSpawn)
            {
                spawnTimer = 0;
                Instantiate(virus, transform.position, Quaternion.Euler(0, 0, 0));
            }

        }

    }


    //how do curing work? on click?
    //public void Spray()
    //{
    //    sprayTimer -= Time.deltaTime;
    //    if (sprayTimer <= 0)
    //    {
    //        cured=true;
    //        Debug.Log("cured!");
    //    }
    //}

    private void OnMouseOver()
    {


        if (Vector3.Distance(player.transform.position, transform.position) <= player.SprayRange)
        {
            Debug.Log("close!");
            if (Input.GetMouseButton(1))
            {
                sprayTimer -= Time.deltaTime;
                Debug.Log("spraying " + sprayTimer);
                if (sprayTimer <= 0)
                {
                    cured = true;
                    GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
            else if (!Input.GetMouseButton(1))
            {

            }
        }
    }
}
