using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedHuman : MonoBehaviour
{

    [SerializeField] int virusSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when this creates virus, it will need to attach the player object here (cant do that on the virus prefab in inspector)
    }

}
