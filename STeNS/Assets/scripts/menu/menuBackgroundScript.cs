using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuBackgroundScript : MonoBehaviour {

    private GameObject[] backgroundObjects;
    public MovieTexture[] backgroundMovies;

    void Start() {
        backgroundObjects = GameObject.FindGameObjectsWithTag("backgroundObject");

        int r = Random.Range(0, backgroundMovies.Length);

        for (int i = 0; i < backgroundObjects.Length; i++) {
            backgroundObjects[i].GetComponent<RawImage>().texture = backgroundMovies[r];
            backgroundMovies[r].loop = true;
            backgroundMovies[r].Play();
        }
    }
}
