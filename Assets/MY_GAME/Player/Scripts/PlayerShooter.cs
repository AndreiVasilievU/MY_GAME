using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform startProjectilePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerAnimator.GetBool("isAttack") == false)
        {
            playerAnimator.SetBool("isAttack", true);

            Instantiate(projectile, startProjectilePoint.position, startProjectilePoint.rotation);
        }
    }
}
