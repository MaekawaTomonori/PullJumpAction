using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour {
    [SerializeField] 
    private Image arrowImage;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            arrowImage.gameObject.SetActive(true);
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0)) {
            Vector3 destination = clickPosition - Input.mousePosition;
            Debug.Log(destination);

            float size = destination.magnitude;

            float angleRad = Mathf.Atan2(destination.y, destination.x);

            arrowImage.rectTransform.position = clickPosition;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);

            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }

        if (Input.GetMouseButtonUp(0)) {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
