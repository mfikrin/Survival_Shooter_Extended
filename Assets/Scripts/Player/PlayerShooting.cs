using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{

    public Text powerAmount;
    public Text speedWeaponAmount;
    public Text diagonalWeaponAmount;
  
    float timer;                                    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit;                            
    int shootableMask;
    int floorMask;                             
    ParticleSystem gunParticles;                    
    LineRenderer gunLine;                           
    AudioSource gunAudio;                           
    Light gunLight;                                 
    float effectsDisplayTime = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        floorMask = LayerMask.GetMask("Floor");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

        if (Player.damagePerShot > Player.maxDamage)
        {
            
            Player.damagePerShot = Player.maxDamage;
            powerAmount.text = Player.damagePerShot.ToString() + "/" + Player.maxDamage.ToString();
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

        diagonalWeaponAmount.text = Player.diagonal.ToString() + "/" + Player.maxDiagonal.ToString();

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
      
            if (Player.timeBetweenBullets < Player.maxTimeBetweenBullets)
            {
                speedWeaponAmount.text = Player.maxTimeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
            else
            {
                speedWeaponAmount.text = Player.timeBetweenBullets.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
        }

        if (WeaponUpgradeManager.isUpPower)
        {
            
            if (Player.damagePerShot > Player.maxDamage)
            {
                powerAmount.text = Player.maxDamage.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
            else
            {
                powerAmount.text = Player.damagePerShot.ToString() + "/" + Player.maxTimeBetweenBullets.ToString();
            }
        }

        if (PowerOrb.isPowerOrb)
        {
            powerAmount.text = Player.damagePerShot.ToString() + "/" + Player.maxDamage.ToString();
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