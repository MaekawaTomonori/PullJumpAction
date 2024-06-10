using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    private Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
    }
    
    private void OnTriggerEnter(Collider other) {
        animator.SetTrigger("Get");
        //DestroySelf();
    }

    private void OnTriggerStay(Collider other) {
    }

    private void OnTriggerExit(Collider other) {
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }
}
