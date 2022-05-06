using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrb : MonoBehaviour
{
    bool isOrbSinking;
    bool playerInRangeOrb;
    public float sinkOrbSpeed = 2.5f;
    PlayerHealth playerHealth;
    GameObject player;
    public static bool isPowerOrb = false;

    public static TimeSpan tsOrb;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    void Update()
    {
        tsOrb = Orb.stopwatchOrb.Elapsed;
        if (tsOrb >= Orb.maxOrbLife || playerInRangeOrb)
        {
            StartOrbSinking();
        }

        if (isOrbSinking)
        {
            // memindahkan object ke bawah
            transform.Translate(-Vector3.up * sinkOrbSpeed * Time.deltaTime);
        }
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter(Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRangeOrb = true;
            isPowerOrb = true;
            Player.damagePerShot += 10;
            if (Player.damagePerShot > Player.maxDamage)
            {
                Player.damagePerShot = Player.maxDamage;
            }
        }
    }

    public void StartOrbSinking()
    {
        isOrbSinking = true;

        Destroy(gameObject, 2f);
    }
}
