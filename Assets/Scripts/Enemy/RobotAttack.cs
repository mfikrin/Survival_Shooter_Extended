using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 30;
        public int timerToDeath = 5;


        Animator anim;
        GameObject player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        ParticleSystem hitParticles;
        bool playerInRange;
        float timer;
        void Awake ()
        {
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            anim = GetComponent <Animator> ();
            hitParticles = GetComponentInChildren<ParticleSystem>();
            // Mendapatkan Enemy health
            enemyHealth = GetComponent<EnemyHealth>();
        }

        // Callback jika ada suatu object masuk ke dalam trigger
        void OnTriggerEnter (Collider other)
        {
            // Set player in range
            if (other.gameObject == player && other.isTrigger == false)
            {
                playerInRange = true;
                
            }
        }

        // Callback jika ada object yang keluar dari trigger
        void OnTriggerExit(Collider other)
        {
            if(other.gameObject == player && other.isTrigger == false)
            {
                playerInRange = false;
            }
        }

        void Update()
        {
            timer += Time.deltaTime;
            if(timer >= timerToDeath){
                enemyHealth.TakeDamage(enemyHealth.currentHealth,enemyHealth.transform.position);
            }

            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack();
            }

            if ((playerHealth.currentHealth <= 0 && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth < 0 && Player.modeGame.Equals("SuddenDeath")))
            {
                anim.SetTrigger("PlayerDead");
            }
        }
        void Attack()
        {
            timer = 0f;

            // Taking damage
            if ((playerHealth.currentHealth > 0 && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth == 0 && Player.modeGame.Equals("SuddenDeath")))
            {
                playerHealth.TakeDamage(attackDamage);
                enemyHealth.TakeDamage(enemyHealth.currentHealth, playerHealth.transform.position);
                hitParticles.Play();

            }

        }
}

