using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] GameObject explosionFX;

    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        if(delay <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        print("Boom");
        Instantiate(explosionFX, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach(Collider nearByObjects in colliders)
        {
            Rigidbody rb = nearByObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(900f, transform.position, 5f);
            }
        }

        Destroy(gameObject);
    }
}
