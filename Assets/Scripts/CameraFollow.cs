using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float followSpeed;

    private Vector3 offset;
    private Vector3 velocity;
    private bool moving = true;

    private void Start() {
        offset = target.position - transform.position;
    }

    private void LateUpdate() {
        if(moving) {
            Vector3 newPos = target.position - offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, followSpeed * Time.timeScale);
        }
    }

    public void Stop() {
        Invoke("StopDelay", 1);
    }

    private void StopDelay() {
        moving = false;
    }
}