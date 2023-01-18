using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageToPlayer;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxVelocity;
    [SerializeField] bool shouldMove; //the viruses should move, but the viral mass should not
    [SerializeField] Player player;

    //variable for sound to play

    [SerializeField] float sprayTimer;


    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTwoardsPlayer();
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).normalized;
        Debug.Log(direction.magnitude);
        Debug.DrawRay(player.transform.position, direction * player.SprayRange); //i dont understand why but this is inaccurate to the range

    }

    void MoveTwoardsPlayer()
    {
        //find the direction of the player, normalize
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);

        //multiply normalized direction by the move speed
        Vector3 movementThisFrame = direction * moveSpeed;


        //add movement to current position
        rigidbody2D.AddForce(movementThisFrame); //does not work with kinematic rigidbody


        //clamp velocity so it doesnt go nuts
        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damageToPlayer);
        }


        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damageToPlayer);
        }
    }


    private void OnMouseOver()
    {


        if (Vector3.Distance(player.transform.position, transform.position) <= player.SprayRange)
        {
            Debug.Log("close!");
            if (Input.GetMouseButton(1))
            {
                sprayTimer -= Time.deltaTime;
                Debug.Log("spraying " + sprayTimer);
                if(sprayTimer <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else if (!Input.GetMouseButton(1))
            {

            }
        }
    }
}
