using UnityEngine;
using System.Collections;

public class testControlScript : MonoBehaviour {

    public float walking;

    void Update() {
        walking = Input.GetAxis("Horizontal");
        GetComponent<Animator>().SetFloat("walk", walking);

        if (walking >= 0.5) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
        }
        else if(walking <= -0.5) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
        }
        else {
            GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        }

        if (Input.GetKey(KeyCode.Space)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10);
        }
    }
}
