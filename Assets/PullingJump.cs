using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PullingJump : MonoBehaviour {

    private Rigidbody rigidbody;
    private Vector3 clickPos;
    private bool isCanJump;

    [SerializeField] private float jumpPower = 12;

    // Start is called before the first frame update
    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
        }


        if (isCanJump && Input.GetMouseButtonUp(0)) {
            Vector3 dest = clickPos - Input.mousePosition;
            if (dest.sqrMagnitude == 0) return;

            rigidbody.velocity = dest.normalized * jumpPower;
        }

        //ChangeGrav(遊び)
        if (transform.position.y < 10) {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }else if (10 <= transform.position.y) {
            Physics.gravity = new Vector3(0, 9.8f, 0);
        }
    }

    private void OnCollisionStay(Collision collision) {
        ContactPoint[] contacts = collision.contacts;
        Vector3 otherNormal = contacts[0].normal;
        Vector3 upVector = new Vector3(0, 1, 0);
        float dotUN = Vector3.Dot(upVector, otherNormal);
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        if (dotDeg <= 45) {
            isCanJump = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        isCanJump = false;
    }
}
