using UnityEngine;
using System.Collections;

public class SkeletonMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float shootingDistance = 10f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
    }

    void Update ()
    {
        float dist = shootingDistance - Vector3.Distance(transform.position, player.transform.position);
        if(dist >= 0) {
            transform.LookAt(player);
            }
        // nav.enabled = false;
        
    }
}
