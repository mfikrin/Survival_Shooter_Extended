using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    //public int damagePerShot = 20;                  
    //public float timeBetweenBullets = 0.15f;        
    //public float range = 100f;
    public Text powerAmount;
    public Text speedWeaponAmount; 

      
    float timer;                                    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit;                            
    int shootableMask;                             
    ParticleSystem gunParticles;                    
    LineRenderer gunLine;                           
    AudioSource gunAudio;                           
    Light gunLight;                                 
    float effectsDisplayTime = 0.2f;
    //int maxDamage = 100;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        if (Player.damagePerShot > Player.maxDamage)
        {
            powerAmount.text = Player.maxDamage.ToString() + "/" + Player.maxDamage.ToString();
        }
        else
        {
            powerAmount.text = Player.damagePerShot.ToString() + "/" + Player.maxDamage.ToString();
        }
        if (Player.timeBetweenBullets < Player.maxTimeBetweenBullets)
        {
            speedWeaponAmount.text = Player.maxTimeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
        }
        else
        {
            speedWeaponAmount.text = Player.timeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= Player.timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= Player.timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

        if (WeaponUpgradeManager.isUpSpeed)
        {
            Debug.Log("UP SPEED WOI");
            if (Player.timeBetweenBullets < Player.maxTimeBetweenBullets)
            {
                speedWeaponAmount.text = Player.maxTimeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
            else
            {
                speedWeaponAmount.text = Player.timeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, Player.range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(Player.damagePerShot, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * Player.range);
        }
    }
}