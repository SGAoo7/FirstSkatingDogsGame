using UnityEngine;
using System.Collections;

public class canvasSetterScript : MonoBehaviour {

    void Start() {
        GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
    }
}
