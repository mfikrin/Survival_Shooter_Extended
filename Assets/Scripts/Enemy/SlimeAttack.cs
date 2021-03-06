using UnityEngine;
using System.Collections;

public class SlimeAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;

    public float timeBetweenBullets = 1f;
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
    public GameObject left;
    public GameObject right;
    // ParticleSystem[] arrowParticle = new ParticleSystem[3];
    // LineRenderer[] arrowLine = new LineRenderer[3];
    
    // AudioSource[] arrowAudio= new AudioSource[3];
    // Light[] arrowLight = new Light[3];           
    ParticleSystem[] arrowParticle = new ParticleSystem[2];
    LineRenderer[] arrowLine = new LineRenderer[2];
    
    AudioSource[] arrowAudio = new AudioSource[2];
    Light[] arrowLight = new Light[2];          
    Ray arrowRay = new Ray();
    RaycastHit arrowHit;              
    float effectsDisplayTime = 0.2f;
    public float shootingDistance = 10f;

    GameObject[] arrows = new GameObject[2];


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
        // arrows = mid;
        // arrowParticle = arrows.GetComponent<ParticleSystem>();
        // // Mendapatkan Line Renderer
        // arrowLine = arrows.GetComponent<LineRenderer>();
        // //arrowLine.SetWidth(0,0.5f);
        // // Mendapatkan Audio Source
        // arrowAudio= arrows.GetComponent<AudioSource>();
        // // Mendapatkan Light
        // arrowLight= arrows.GetComponent<Light>();
        arrows[0] = left;
        arrows[1] = right;
        for (int i = 0; i < 2; i++)
        {
            arrowParticle[i] = arrows[i].GetComponent<ParticleSystem>();
            // Mendapatkan Line Renderer
            arrowLine[i] = arrows[i].GetComponent<LineRenderer>();
            // Mendapatkan Audio Source
            arrowAudio[i] = arrows[i].GetComponent<AudioSource>();
            // Mendapatkan Light
            arrowLight[i] = arrows[i].GetComponent<Light>();
        }

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
                if (timer >= timeBetweenBullets && Time.timeScale != 0 && ((playerHealth.currentHealth > 0 && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth == 0 && Player.modeGame.Equals("SuddenDeath")))){
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
        for (int i = 0; i < 2; i++)
        {
            arrowAudio[i].Play();
            arrowLight[i].enabled = true;
            arrowParticle[i].Stop();
            arrowParticle[i].Play();
            arrowLine[i].enabled = true;
            arrowLine[i].SetPosition(0, arrows[i].transform.position);
            arrowRay.origin = arrows[i].transform.position;
            arrowRay.direction = arrows[i].transform.forward;
            if (Physics.Raycast(arrowRay, out arrowHit, range, shootableMask))
            {
                PlayerHealth pHealth = arrowHit.collider.GetComponent<PlayerHealth>();
                if (pHealth != null)
                {
                    pHealth.TakeDamage(rangedDamage);
                    arrowLine[i].SetPosition(1, pHealth.transform.position);
                }
                else{
                    arrowLine[i].SetPosition(1, arrowHit.point);
                }
            }
            else
            {
                arrowLine[i].SetPosition(1, arrowRay.origin + arrowRay.direction * range);
            }   
        }    
    }

    void DisableEffects()
    {
            arrowLine[0].enabled = false;
            arrowLight[0].enabled = false;
                
            arrowLine[1].enabled = false;
            arrowLight[1].enabled = false;        
        
    }
    
}
