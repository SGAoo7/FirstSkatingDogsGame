using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public void openURL(string url) {
        Application.OpenURL(url);
    }
}
