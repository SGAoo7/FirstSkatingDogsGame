using UnityEngine;
using System.Collections;

public class movieSetterScript : MonoBehaviour {

    public Material movTexture;

    public movieScript[] _MS;

    void Awake () {
        _MS = GetComponentsInChildren<movieScript>();
    }
    void Start() {
        for (int i = 0; i < _MS.Length; i++) {
            //_MS[i].movTexture = movTexture;
        }
    }
}
