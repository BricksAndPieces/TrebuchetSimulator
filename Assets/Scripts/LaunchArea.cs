using UnityEngine;

public class LaunchArea : MonoBehaviour {


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Projectile")) {
            GameObject projectile = other.gameObject;
            HingeJoint joint = projectile.GetComponent<HingeJoint>();
            Destroy(joint);
        }
    }
}