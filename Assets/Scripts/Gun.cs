﻿using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform playerCamera;
    public float shootDistance = 10f;
    public float impactForce = 100f;
    public LayerMask shootMask;
    public ParticleSystem shootParticles;
    public GameObject hitEffect;
    public GameObject destroyEffect;
    public GameObject smokeEffect;
    


    private RaycastHit shootRaycastHit;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    { 

        shootParticles.Play();

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out shootRaycastHit, shootDistance, shootMask))
        {
            if (!shootRaycastHit.collider.CompareTag("Key"))
            {
                Instantiate(hitEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal), shootRaycastHit.transform);
            }

            if (shootRaycastHit.collider.GetComponent<Rigidbody>() != null)
            {
                shootRaycastHit.collider.GetComponent<Rigidbody>().AddForce(-shootRaycastHit.normal * impactForce);
            }

            if (shootRaycastHit.collider.CompareTag("Barrel"))
            {
                Destroy(shootRaycastHit.collider.gameObject);
                Instantiate(destroyEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal));

                //Cada vez que se destruya un barril "TimeUp" el tiempo aumentará
                LevelManager.Instance.levelTimer = LevelManager.Instance.levelTimer + LevelManager.Instance.levelTimeIncrease;

            }
            if (shootRaycastHit.collider.CompareTag("Pipe"))
            {

                Instantiate(smokeEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal));

            }
        }

    }
}
