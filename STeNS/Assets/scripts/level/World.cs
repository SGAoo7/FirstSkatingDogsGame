using UnityEngine;
using System.Collections;

public class World {

    //the world class has a certain length and height variable
    int width;
    int height;

    int multiX;
    int multiY;

    //constructor for the world class
    //where you can pass a certain heigth and length to.
    public World(int w,int h) {
        width = w;
        height = h;
    }
    public void GiveData() {
        multiX = worldMakerScript.instance.spaceBetweenObjectsX;
        multiY = worldMakerScript.instance.spaceBetweenObjectsY;
    }
    //function to populate the world array with players and enemies.
    public void populate() {

        //for every time the width is long do this.
        for (int x = 0; x < width; x++) {

            //for every time the height is high do this.
            for (int y = 0; y < height; y++) {

                int r;

                if (x == 0 && y == 0 || x == width - 1 && y == height - 1) {
                    r = 0;
                    GameObject a = worldMakerScript.instance.GenerateObject(0);
                    a.transform.position = new Vector3(x * multiX, y * multiY, 0);
                }
                else {
                    r = Random.Range(0, worldMakerScript.instance.objects.Length);
                    GameObject a = worldMakerScript.instance.GenerateObject(r);
                    a.transform.position = new Vector3(x * multiX, y * multiY, 0);
                    //worldMakerScript.instance.GiveAnimation(a);

                    int rDestroy = Random.Range(0, 2);

                    switch (rDestroy) {
                        case 0:
                            worldMakerScript.instance.DontDestroy(a);
                            break;
                        default:
                            worldMakerScript.instance.DestroyObject(a);
                            break;
                    }
                }
            }
        }
    }
}
