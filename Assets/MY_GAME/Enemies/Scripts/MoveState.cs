using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] float speed;

    private void Start()
    {
        enemyData.enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (enemyData.playerTransform != null)
        {
            LookAtPlayer();
            MoveToPlayer();
        }
    }

    private void LookAtPlayer()
    {
        transform.LookAt(enemyData.playerTransform.position);
    }

    private void MoveToPlayer()
    {
        var directionToPlayer = enemyData.playerTransform.position - transform.position;

        enemyData.enemyRigidbody.velocity = directionToPlayer * speed * Time.deltaTime;
    }
}