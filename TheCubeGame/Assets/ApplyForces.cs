using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForces : MonoBehaviour
{
    Rigidbody ourRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ourRigidBody.AddExplosionForce(1000, transform.position + Vector3.down, 2);
        }
            
        
    }

    private void OnCollisionEnter(Collision collision)
    {
     Health objectHitHealth =   collision.gameObject.GetComponent<Health>();

        if (objectHitHealth)
        {
            print("Found Health script in object hit");
            objectHitHealth.takeDamage(3);

            int ObjectsMaxHealth = objectHitHealth.whatsYourMaxHealth();
            if  (ObjectsMaxHealth > 100)
                objectHitHealth.takeDamage(100);
        }
        else
        {
            print("Did'nt find Health script in object hit");
        }
    }


}
