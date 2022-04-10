using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth RobotHealth;
    UnityEngine.AI.NavMeshAgent nav;

    public float speed = 7f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        RobotHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
        nav.speed = speed;
        
    }


    void Update ()
    {
        //Memindahkan posisi player
        //Debug.Log("Nav Speed" + nav.speed);
        if (RobotHealth.currentHealth > 0 && ((playerHealth.currentHealth > 0 && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth == 0 && Player.modeGame.Equals("SuddenDeath"))))
        {
            //Debug.Log("MASUK KE NAV MESHAN");
            nav.SetDestination(player.position);
        }
        else //Hentikan moving
        {
            nav.enabled = false;
        }
    }
}
