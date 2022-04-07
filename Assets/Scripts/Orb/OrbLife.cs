using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLife : MonoBehaviour
{
    bool playerInRangeOrb;
    bool isOrbSinking;
    public float sinkOrbSpeed = 2.5f;
    GameObject player;
    PlayerHealth playerHealth;
    public static TimeSpan tsOrb;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    void Update()
    {
        tsOrb = Orb.stopwatchOrb.Elapsed;
        if (tsOrb >= Orb.maxOrbLife)
        {
            StartOrbSinking();
        }

        if (isOrbSinking)
        {
            // memindahkan object ke bawah
            transform.Translate(-Vector3.up * sinkOrbSpeed * Time.deltaTime);
        }
    }

    public void StartOrbSinking()
    {
        isOrbSinking = true;

        Destroy(gameObject, 2f);
    }
}
