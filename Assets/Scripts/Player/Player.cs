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
    public static int damagePerShot = 100;
    public static float timeBetweenBullets = 0.5f;
    public static float range = 100f;
    public static int maxDamage = 100;
    public static float maxTimeBetweenBullets = 0.1f; 

    // PlayerMovement
    public static float speed = 6f;
    public static float camRayLength = 100f;
    public static float maxSpeed = 50f;

    // PlayerHealth
    public static int startingHealth = 100;
    public static int maxHealth = 100;
    public static float flashSpeed = 5f;
    public static Color flashColour = new Color(1f, 0f, 0f, 0.1f);  




    // Start is called before the first frame update
    void Start()
    {
        //if (playerName.Length > 20 && (playerName != MainMenu.defaultPlayerName))
        //{
        //    string displayName = playerName.Substring(0, 20);
        //    //Debug.Log("Display name");
        //    UnityEngine.Debug.Log(displayName.Length);
        //    playerNameText.text = displayName;
        //}
        //else
        //{
        //    playerNameText.text = playerName;
        //}

        UnityEngine.Debug.Log("MODE GAME");
        modeGame = "Wave";
        UnityEngine.Debug.Log(modeGame);

        playerName = "Playerss";
        playerNameText.text = "Playerss";

        //Debug.Log(playerName);
        //Debug.Log(playerName.Length);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
