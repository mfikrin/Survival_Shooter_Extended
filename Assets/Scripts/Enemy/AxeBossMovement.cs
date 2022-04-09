using UnityEngine;
using System.Collections;

public class AxeBossMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float rotSpeed = 5.0f;
    float speed = 7f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
    }


    void Update ()
    {
        //Memindahkan posisi player
        //transform.Rotate (0,0,50*Time.deltaTime);
        if (enemyHealth.currentHealth > 0 && ((playerHealth.currentHealth > 0 && Player.modeGame != "SuddenDeath") || (playerHealth.currentHealth == 0 && Player.modeGame.Equals("SuddenDeath"))))
        {
            Debug.Log("MASUK KE NAV MESHAN");
            nav.SetDestination(player.position);
        }
        else //Hentikan moving
        {
            nav.enabled = false;
        }
    }

    // void FaceTarget(Vector3 destination)
    // {
    //     Vector3 lookPos = destination - transform.position;
    //     lookPos.y = 0;
    //     Quaternion rotation = Quaternion.LookRotation(lookPos);
    //     transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed);  
    // }
}