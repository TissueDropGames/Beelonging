﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollision : MonoBehaviour
{

    public AudioClip deathsound;
    public AudioClip honeycomb_pickup;
    public AudioClip honeycomb_activate;

    private AudioSource source;

    [HideInInspector]
    public bool bIsDead;

    private void Awake()
    {
        bIsDead = false;
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D p_xOtherCollider)
    {
        if (!BeeManager.bIsInvincible)
        {
            if (p_xOtherCollider.gameObject.CompareTag("Enemy") ||
                p_xOtherCollider.gameObject.CompareTag("EnemyProjectile"))
            {
                source.PlayOneShot(deathsound, 1F);
                //TODO: Death Animation
                BeeManager.KillBeell(gameObject);
            }
        }

        if (p_xOtherCollider.gameObject.CompareTag("HoneycombPickUp"))
        {
            if (BeeManager.iPowerUpCounter >= 3)
            {
                source.PlayOneShot(honeycomb_pickup, 1F);
                InvincibilityCounter.fInvincibilityTimer += 1;
                Destroy(p_xOtherCollider.gameObject);
            }
            else
            {
                BeeManager.iPowerUpCounter++;
                Destroy(p_xOtherCollider.gameObject);
                if (BeeManager.iPowerUpCounter == 3)
                {
                    source.PlayOneShot(honeycomb_activate, 1F);
                }

                else
                {
                    source.PlayOneShot(honeycomb_pickup, 1F);
                }
            }
        }
    }
}
