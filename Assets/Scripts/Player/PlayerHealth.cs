using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{
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


    void Awake()
    {
        // Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = Player.startingHealth;
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
            healthAmount.text = currentHealth.ToString() + "/" + Player.maxHealth.ToString();
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

        if (currentHealth <= 0 && !isDead)
        {
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

        ScoreZenUI.TimeSpanZenUI = ScoreManager.stopwatch.Elapsed;

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

    }
}
