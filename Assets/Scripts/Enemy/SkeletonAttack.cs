using UnityEngine;
using System.Collections;

public class SkeletonAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;

    public float timeBetweenBullets = 2f;
    public int attackDamage = 10;
    public int rangedDamage = 5;
    public static float range = 10f;
    int shootableMask;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    public GameObject arrows;
    ParticleSystem arrowParticle;
    LineRenderer arrowLine;
    
    AudioSource arrowAudio;
    Light arrowLight;                   
    Ray arrowRay = new Ray();
    RaycastHit arrowHit;              
    float effectsDisplayTime = 0.2f;
    float shootingDistance = 10f;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        // arrows = GameObject.FindGameObjectWithTag ("Projectile");
        shootableMask = LayerMask.GetMask ("Shootable");
        playerHealth = player.GetComponent <PlayerHealth> ();
        anim = GetComponent <Animator> ();
        anim.Play ("Spawn");
        //anim.SetTrigger("Spawn");
        // Mendapatkan Enemy health
        enemyHealth = GetComponent<EnemyHealth>();
        
        // Mendapatkan Particle System
        arrowParticle = arrows.GetComponent<ParticleSystem>();
        // Mendapatkan Line Renderer
        arrowLine = arrows.GetComponent<LineRenderer>();
        // Mendapatkan Audio Source
        arrowAudio = arrows.GetComponent<AudioSource>();
        // Mendapatkan Light
        arrowLight = arrows.GetComponent<Light>();




    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
            anim.Play("Melee");
            
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
        float dist = shootingDistance - Vector3.Distance(transform.position, player.transform.position);
        if(dist < 0)
        {
            //anim.Play("Idle");
        }
        else{
            if(timer >= timeBetweenAttacks && !playerInRange && enemyHealth.currentHealth > 0)
            {
                if (timer >= timeBetweenBullets && Time.timeScale != 0 && playerHealth.currentHealth > 0){
                    anim.Play("Attack");
                    Shoot();
                }
            }
        }
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (timer >= Player.timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
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
        }
    }

    void Shoot()
    {
        timer = 0f;
        arrowAudio.Play();
        arrowLight.enabled = true;
        arrowParticle.Stop();
        arrowParticle.Play();
        arrowLine.enabled = true;
        arrowLine.SetPosition(0, arrows.transform.position);
        arrowRay.origin = arrows.transform.position;
        arrowRay.direction = arrows.transform.forward;
        if (Physics.Raycast(arrowRay, out arrowHit, range, shootableMask))
        {
            PlayerHealth pHealth = arrowHit.collider.GetComponent<PlayerHealth>();
            Vector3 hitPoint = arrowHit.point;
            if (pHealth != null)
            {
                // Debug.Log("Player Health : " + pHealth.currentHealth);
                // Debug.Log("Distance : " + dist);
                pHealth.TakeDamage(rangedDamage);
                arrowLine.SetPosition(1, pHealth.transform.position);
            }
            else{
                arrowLine.SetPosition(1, hitPoint);
            }
        }
        else
        {
            arrowLine.SetPosition(1, arrowRay.origin + arrowRay.direction * range);
        }

        
    }

    void DisableEffects()
    {
        arrowLine.enabled = false;
        arrowLight.enabled = false;
    }

    
}
