using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem system;

   
    public int damage;
    List<ParticleCollisionEvent> collisionEvents;
    void Start()
    {
        system = GetComponent<ParticleSystem>();

    }
    void setDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnParticleCollision(GameObject other)
    {
        int item = system.GetCollisionEvents(other, collisionEvents);


        if (other.tag == "ENEMY")
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            enemy.TakeDamage(damage);

        }
    }
    // Update is called once per frame
    void Update()
    {
         StartShooting();
    }
    public void StartShooting()
    {
        //if (canShoot)
        // {
        system.Play();
        //Debug.Log("Particles Shoooo");
        // }
    }
    public void StopShooting()
    {
        // system.Stop();
        // canShoot = false;
        // Debug.Log("Stop Shooting Pls Pls FFS");
    }
}
