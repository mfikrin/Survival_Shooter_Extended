using UnityEngine;
using System.Collections;

public class SkeletonAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;

    public float timeBetweenBullets = 1f;
    public int attackDamage = 10;
    public int rangedDamage = 5;
    public static float range = 50f;
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


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        // arrows = GameObject.FindGameObjectWithTag ("Projectile");
        shootableMask = LayerMask.GetMask ("Shootable");
        playerHealth = player.GetComponent <PlayerHealth> ();
        anim = GetComponent <Animator> ();
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
            //anim.SetBool("PlayerInRange", true);
            
        }
    }

    // Callback jika ada object yang keluar dari trigger
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = false;
            //anim.SetBool("PlayerInRange", false);
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= timeBetweenAttacks && !playerInRange && enemyHealth.currentHealth > 0)
        {
            if (timer >= timeBetweenBullets && Time.timeScale != 0){
                Shoot();
            }
        }
        else if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (timer >= Player.timeBetweenBullets * effectsDisplayTime)
        {
        DisableEffects();
        }


        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f;

        // Taking damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void Shoot()
    {
        anim.SetBool("PlayerInRange", true);
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

            if (pHealth != null)
            {
                Debug.Log("Player Health : " + pHealth.currentHealth);
                //pHealth.TakeDamage(rangedDamage);
            }

            arrowLine.SetPosition(1, arrowHit.point);
        }
        else
        {
            arrowLine.SetPosition(1, arrowRay.origin + arrowRay.direction * range);
        }

        // shoot projectile
        
    }

    void DisableEffects()
    {
        arrowLine.enabled = false;
        arrowLight.enabled = false;
    }

    
}