using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    

    public static string playerName;
    public Text playerNameText;

    // PlayerShooting
    public static int damagePerShot = 20;
    public static float timeBetweenBullets = 0.15f;
    public static float range = 100f;
    public static int maxDamage = 100;

    // PlayerMovement
    public static float speed = 6f;
    public static float camRayLength = 100f;
    public static float maxSpeed = 50f;

    // PlayerHealth
    public static int startingHealth = 100;
    //public static int currentHealth;
    public static int maxHealth = 100;
    public static float flashSpeed = 5f;
    public static Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = playerName;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
