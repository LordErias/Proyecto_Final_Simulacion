﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelManager : MonoBehaviour
{

    public int vida = 100;
    public ParticleSystem dead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown("t"))
        {  
            launchParticles();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        launchParticles();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
        print("Perdiste");
    }
    private void launchParticles(){
        print("launch");
        ParticleSystem ps = Instantiate(dead, transform.position, Quaternion.identity);
        ps.Play();
    }

    void OnTriggerEnter(Collider other) {
        print("hit");
        if (other.tag == "Enemy")
        {
            vida -= other.GetComponent<EnemyMovement>().damage;
            Destroy(other.gameObject);
        }
        print(vida);
    }
}
