using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class worldMakerScript : MonoBehaviour {

    public static worldMakerScript instance;

    public int width;
    public int height;

    public int spaceBetweenObjectsX;
    public int spaceBetweenObjectsY;

    public GameObject[] objects;

    [HideInInspector]
    public List<GameObject> spawnedObjects = new List<GameObject>();

    //a instance of the world class.
    World world;

    void Awake() {
        if (instance == null) {
            instance = this;
            world = new World(width, height);
            world.GiveData();
            world.populate();
            
        }
        else {
            Destroy(gameObject);
        }
    }
    public GameObject GenerateObject(int spawn) {

        GameObject o = Instantiate(objects[spawn], transform.position, Quaternion.identity) as GameObject;

        GameObject parent = GameObject.FindGameObjectWithTag("objects");
        o.transform.SetParent(parent.transform);

        return o;
    }
    public void GiveAnimation(GameObject other) {
        int r = Random.Range(0, 3);

        switch (r) {
            case 0:
                other.GetComponent<Animator>().SetInteger("rotate", 1);
                break;
            case 1:
                other.GetComponent<Animator>().SetInteger("rotate", 2);
                break;
            case 2:
                other.GetComponent<Animator>().SetInteger("rotate", 3);
                break;
        }
    }
    public void DestroyObject(GameObject other) {
        Destroy(other);
    }
    public void DontDestroy(GameObject other) {
        spawnedObjects.Add(other);
    }
}