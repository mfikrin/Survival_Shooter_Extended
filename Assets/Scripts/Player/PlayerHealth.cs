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
            Death();
        }
    }


    void Death()
    {
        ScoreManager.stopwatch.Stop();
        if (Player.modeGame.Equals("Zen"))
        {
            ScoreZenManager.TimeSpanZenUI = ScoreManager.stopwatch.Elapsed;


        }
        else if (Player.modeGame.Equals("SuddenDeath"))
        {
            ScoreSuddenDeathManager.TimeSpanSuddenDeathUI = ScoreManager.stopwatch.Elapsed;
        }
        
    
       
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        //meload ulang scene dengan index 0 pada build setting

        string lastGameMode = Player.modeGame;
        OverMenu.GameMode = lastGameMode;
        OverMenu.defaultPlayerName = Player.playerName;
        if (Player.modeGame.Equals("Zen"))
        {   
            TimeSpan newTime = new TimeSpan(ScoreZenManager.TimeSpanZenUI.Days, ScoreZenManager.TimeSpanZenUI.Hours, ScoreZenManager.TimeSpanZenUI.Minutes, ScoreZenManager.TimeSpanZenUI.Seconds, ScoreZenManager.TimeSpanZenUI.Milliseconds);
            string insertedScore = newTime.ToString().Substring(0,11);
            OverMenu.Param1 = insertedScore;
            OverMenu.Param2 = insertedScore;
            SceneManager.LoadScene("ZenOverMenu");
       
        }
        else if (Player.modeGame.Equals("Wave"))
        {
            // set score
            OverMenu.Param1 = ScoreManager.wave.ToString();
            OverMenu.Param2 = ScoreManager.score.ToString();
          
            SceneManager.LoadScene("WaveOverMenu");
       
        }
        else if (Player.modeGame.Equals("SuddenDeath"))
        {
            // set score
            TimeSpan newTime = new TimeSpan(ScoreSuddenDeathManager.TimeSpanSuddenDeathUI.Days, ScoreSuddenDeathManager.TimeSpanSuddenDeathUI.Hours, ScoreSuddenDeathManager.TimeSpanSuddenDeathUI.Minutes, ScoreSuddenDeathManager.TimeSpanSuddenDeathUI.Seconds, ScoreSuddenDeathManager.TimeSpanSuddenDeathUI.Milliseconds);
            string insertedScore = newTime.ToString().Substring(0,11);
            OverMenu.Param1 = insertedScore;
            OverMenu.Param2 = ScoreManager.score.ToString();
          
            SceneManager.LoadScene("SuddenDeathOverMenu");

        }
        

    }
}
