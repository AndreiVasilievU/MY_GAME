using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject projectilePS;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float timeToDestroyCollision;

    private Rigidbody projectileRigidbody;

    private void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();

        projectileRigidbody.AddForce(transform.forward * flySpeed, ForceMode.Impulse);

        StartCoroutine(DestroyAtTime(timeToDestroy));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            projectilePS.SetActive(false);
            explosion.SetActive(true);
            projectileRigidbody.velocity = Vector3.zero;
            Destroy(gameObject, timeToDestroyCollision);
        }
    }

    IEnumerator DestroyAtTime(float timeToDestroy)
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(gameObject);
    }
}
