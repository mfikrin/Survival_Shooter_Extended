using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public static string playerName;
    public Text playerNameText;
    public static string modeGame;

    // PlayerShooting
    public static int damagePerShot = 20;
    public static float timeBetweenBullets = 0.5f;
    public static float range = 100f;
    public static int maxDamage = 100;
    public static float maxTimeBetweenBullets = 0.1f;

    // Guns 
    public static int diagonal = 1;
    public static int maxDiagonal = 5;

    // PlayerMovement
    public static float speed = 6f;
    public static float camRayLength = 100f;
    public static float maxSpeed = 50f;

    // PlayerHealth
    public static int startingHealth = 100;
    public static int maxHealth = 100;
    //public static int currentHealth = startingHealth;
    public static float flashSpeed = 5f;
    public static Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    // Start is called before the first frame update
    void Awake()
    {
        if (playerName.Length > 20 && (playerName != MainMenu.defaultPlayerName))
        {
            string displayName = playerName.Substring(0, 20);
            UnityEngine.Debug.Log(displayName.Length);
            playerNameText.text = displayName;
        }
        else
        {
            playerNameText.text = playerName;
        }

        if (modeGame.Equals("SuddenDeath"))
        {
            startingHealth = 0;
        }
        else
        {
            startingHealth = 100;
        }
    }
}
