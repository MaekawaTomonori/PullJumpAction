using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour {

    private Rigidbody rigidbody;
    private Vector3 clickPos;

    [SerializeField] private float jumpPower = 10;

    // Start is called before the first frame update
    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            Vector3 dest = clickPos - Input.mousePosition;
            if (dest.sqrMagnitude == 0) return;

            rigidbody.velocity = dest.normalized * jumpPower;
        }

        if (transform.position.y < 10 && 0 < Physics.gravity.y) {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        if (10 <= transform.position.y && Physics.gravity.y < 0) {
            Physics.gravity = new Vector3(0, 9.8f, 0);
        }
    }
}
