using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    ParticleSystem explosionParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake()
    {
        // Mendapatkan reference component
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();

        capsuleCollider = GetComponent<CapsuleCollider>();

        // Set current health
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (isSinking)
        {
            // memindahkan object ke bawah
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;


        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }


    public void StartSinking()
    {
        // Disable NavMesh component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Set Rigidbody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        
        if (Player.modeGame.Equals("Wave"))
        {
            EnemyWaveManager.enemyKilled++;
        }
        //EnemyWaveManager.enemyKilled++;
        Destroy(gameObject, 2f);
    }
}
