using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        Invoke("DestroyLater", 0.01f);
    }

    private void DestroyLater() {
        Destroy(gameObject);
    }
}