using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    // TODO make vars for this
    static bool x = true;

    private void Start() {
        x = true;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Projectile")) {
            if (x)
            {
                x = false;

                Collider[] objects = Physics.OverlapSphere(transform.position, 20);
                foreach (Collider h in objects)
                {
                    Rigidbody r = h.GetComponent<Rigidbody>();
                    if (r != null && !r.gameObject.CompareTag("Projectile"))
                    {
                        r.AddExplosionForce(1000, transform.position, 20);
                    }
                }


                GameObject g = GameObject.Find("ProjectileCam");
                if (g != null)
                {
                    g.GetComponent<CameraFollow>().Stop();
                }

                Vector3 vel = collision.gameObject.GetComponent<Rigidbody>().velocity;
                collision.gameObject.GetComponent<Rigidbody>().velocity = vel / 10;

                GameObject.Find("Manager").GetComponent<SimulationManager>().Restart();
            }
        }
    }
}
