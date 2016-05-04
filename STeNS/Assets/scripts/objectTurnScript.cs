using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectTurnScript : MonoBehaviour {

    private List<GameObject> objectsInGame = new List<GameObject>();

    public float moveTimer;
    private float realMoveTimer;

    private int moveWay;

    void Start() {
        moveWay = 0;

        realMoveTimer = moveTimer;

        for (int i = 0; i < worldMakerScript.instance.spawnedObjects.Count; i++) {
            objectsInGame.Add(worldMakerScript.instance.spawnedObjects[i]);
        }
    }
    void Update() {
        realMoveTimer -= Time.deltaTime;

        if (realMoveTimer <= 0) {

            int r = Random.Range(0,(objectsInGame.Count));

            //objectsInGame[r].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);

            objectsInGame[r].AddComponent<objectMovementScript>();

            //objectsInGame[r].GetComponent<objectMovementScript>().enabled = true;

            realMoveTimer = moveTimer;
        }
    }
}
