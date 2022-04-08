using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    bool isOrbSinking;
    bool playerInRangeOrb;
    public float sinkOrbSpeed = 2.5f;
    PlayerHealth playerHealth;
    GameObject player;
    public static bool isHealthOrb = false;

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
            Debug.Log("MASUK KE ORB RED - HEALTH");
            playerInRangeOrb = true;
            isHealthOrb = true;

            playerHealth.currentHealth += 25;

            if (playerHealth.currentHealth > Player.maxHealth)
            {
                playerHealth.currentHealth = Player.maxHealth;
            }
        }
    }

    public void StartOrbSinking()
    {
        isOrbSinking = true;

        Destroy(gameObject, 2f);
    }
}
