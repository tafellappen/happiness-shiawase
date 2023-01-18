using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageToPlayer;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxVelocity;
    [SerializeField] Player player;

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
    }

    private void MoveTwoardsPlayer()
    {
        //find the direction of the player, normalize
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);

        //multiply normalized direction by the move speed
        Vector3 movementThisFrame = direction * moveSpeed;


        //add movement to current position
        rigidbody2D.AddForce(movementThisFrame);

        //clamp velocity so it doesnt go nuts
        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxVelocity);
    }
}
