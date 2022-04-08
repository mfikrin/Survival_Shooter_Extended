using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAttack : MonoBehaviour
{
  
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRangeOrb;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter(Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRangeOrb = true;
        }
    }

    //// Callback jika ada object yang keluar dari trigger
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player && other.isTrigger == false)
    //    {
    //        playerInRange = false;
    //    }
    //}


    void Update()
    {
        if (playerInRangeOrb)
        {

        }
    }


    
}
