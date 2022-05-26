using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransition : Transition
{
    private void OnEnable()
    {
        NeedTransit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NeedTransit = true;
            enemyData.playerTransform = other.transform;

            gameObject.SetActive(false);
        }
    }
}
