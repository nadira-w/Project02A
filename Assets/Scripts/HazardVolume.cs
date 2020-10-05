using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    //[SerializeField] AudioClip _deathSound = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player
            = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            //AudioHelper.PlayClip2D(_deathSound, 1);
            player.TakeDamage();
        }

    }
}
