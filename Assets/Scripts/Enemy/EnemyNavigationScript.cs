using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField]EnemyScriptableObject enemyStats;
    NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void OnEnable()
    {
        player = PlayerGetTransform.playerTransform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyStats.speed;
        agent.stoppingDistance = enemyStats.stopingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        if (agent.acceleration != 0)
        {
            animator.SetBool("walk", true);
            return;
        }
        animator.SetBool("walk", false);
    }
}
