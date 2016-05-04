using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class movieScript : MonoBehaviour {

    public MovieTexture movTexture;

    private float timer;
    public bool canNotActivate;

    void Start() {
        timer = Random.Range(0, 5);

        
        movTexture.Pause();
    }
    void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0 && canNotActivate == false) {

            Renderer r = GetComponent<Renderer>();

            GetComponent<RawImage>().texture = movTexture as MovieTexture;

            movTexture.loop = true;
            movTexture.Play();

            canNotActivate = true;
        }
    }
}