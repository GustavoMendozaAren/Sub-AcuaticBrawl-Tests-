using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    public int damageAmount = 2;

    private bool Weapon1 = false;

    private Rigidbody bulletRigidbody;
    public Transform WeaponC1;
    public Transform WeaponC2;
    public Transform VfxHitTarget;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 70f;
        bulletRigidbody.velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider another)
    {
        if (another.CompareTag("Enemy"))
        {
            
            //Debug.Log("HitEnemy");
            another.GetComponent<EnemyHealth>().ApplyDamage(damageAmount);
        }

        if (another.GetComponent<BulletTarget>() != null)
        {
            
            //Hit target
            Instantiate(VfxHitTarget, transform.position, Quaternion.identity);

        }
        else
        {
            if (GameplaycontrollerS.instance.Weapon1 == false)
            {
                //print("Hola");
                Instantiate(WeaponC1, transform.position, Quaternion.identity);
            }
            if (GameplaycontrollerS.instance.Weapon1 == true)
            {
                //print("Adios");
                Instantiate(WeaponC2, transform.position, Quaternion.identity);
            }
            //Hit something else
            
        }
        Destroy(gameObject);
    }
    

}
