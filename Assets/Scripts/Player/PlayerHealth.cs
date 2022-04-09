using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static int tempcurrenthealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public Text healthAmount;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    //void Start()
    //{
    //    if (Player.modeGame.Equals("SuddenDeath"))
    //    {
    //        currentHealth = tempcurrenthealth;
    //    }
    //    else
    //    {
    //        currentHealth = Player.startingHealth;
    //    }
    //}
    void Awake()
    {
        // Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();




        //Debug.Log(tempcurrenthealth);

        //currentHealth = tempcurrenthealth;
        currentHealth = Player.startingHealth;
        Debug.Log("CURRENT HEALT");
        Debug.Log(currentHealth.ToString());
        if (Player.startingHealth > Player.maxHealth)
        {
            healthAmount.text = Player.maxHealth.ToString() + "/" + Player.maxHealth.ToString();
        }
        else
        {
            healthAmount.text = Player.startingHealth.ToString() + "/" + Player.maxHealth.ToString();
        }
    }


    void Update()
    {
        if (damaged)
        {
            // Merubah warna gambar menjadi value dari flashColour
            damageImage.color = Player.flashColour;
        }
        else
        {
            // Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, Player.flashSpeed * Time.deltaTime);
        }

        damaged = false;

        if (HealthOrb.isHealthOrb)
        {
            //if (currentHealth < 0)
            //{
            //    currentHealth = 0;
            //}

            healthAmount.text = currentHealth.ToString() + "/" + Player.maxHealth.ToString();

        }

        if (isDead)
        {
            if (Player.modeGame.Equals("SuddenDeath"))
            {
                healthAmount.text = "DEATH";
            }
            else
            {
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }
                healthAmount.text = currentHealth.ToString() + "/" + Player.maxHealth.ToString();
            }
        }

    }

    // Fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        healthAmount.text = currentHealth.ToString() + "/" + Player.maxHealth.ToString();

        playerAudio.Play();

        if ((currentHealth <= 0 && !isDead && Player.modeGame != "SuddenDeath") || (currentHealth < 0 && Player.modeGame.Equals("SuddenDeath")) )
        {
            //currentHealth = 0;
            Death();
        }
    }
    // public void TakeRangedDamage(int amount, Vector3 hitPoint)
    // {
    //     if (isDead)
    //         return;

    //     playerAudio.Play();
    //     currentHealth -= amount;

    //     hitParticles.transform.position = hitPoint;
    //     hitParticles.Play();

    //     if (currentHealth <= 0  && !isDead)
    //     {
    //         Death();
    //     }
    // }


    void Death()
    {
        ScoreManager.stopwatch.Stop();
        //ScoreManager.ts = ScoreManager.stopwatch.Elapsed;
        if (Player.modeGame.Equals("Zen"))
        {
            ScoreZenUI.TimeSpanZenUI = ScoreManager.stopwatch.Elapsed;


        }
        else if (Player.modeGame.Equals("SuddenDeath"))
        {
            ScoreSuddenDeathUI.TimeSpanSuddenDeathUI = ScoreManager.stopwatch.Elapsed;
        }
        

        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");
        //anim.SetBool("Die", true);

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        //meload ulang scene dengan index 0 pada build setting


        //ScoreZenUI.scoreUI = ScoreManager.score;
        if (Player.modeGame.Equals("Zen"))
        {
            // set time in void Death()
            SceneManager.LoadScene("ZenScoreBoard");
        }
        else if (Player.modeGame.Equals("Wave"))
        {
            // set score
            ScoreWaveUI.scoreWaveUI = ScoreManager.score;
            // set wave
            ScoreWaveUI.waveWaveUI = ScoreManager.wave;

            SceneManager.LoadScene("WaveScoreBoard");
        }
        else if (Player.modeGame.Equals("SuddenDeath"))
        {
            // set score
            ScoreSuddenDeathUI.scoreSuddenDeathUI = ScoreManager.score;
            // set wave
            ScoreWaveUI.waveWaveUI = ScoreManager.wave;

            SceneManager.LoadScene("SuddenDeathScoreBoard");
        }

    }
}
