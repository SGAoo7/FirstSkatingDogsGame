using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectMovementScript : MonoBehaviour {

    private List<int> rMoveNumbers = new List<int>();

    private int moveWay;
    private int rWay;

    private Vector3 _right;
    private Vector3 _left;
    private Vector3 _up;
    private Vector3 _down;

    private float despawnTimer;

    void Start () {
        despawnTimer = 2;

        rMoveNumbers.Add(0);
        rMoveNumbers.Add(1);
        rMoveNumbers.Add(2);
        rMoveNumbers.Add(3);

        Raycasting();

        _right = new Vector3(transform.position.x + 3, transform.position.y);
        _left = new Vector3( transform.position.x -3, transform.position.y);
        _up = new Vector3(transform.position.x,transform.position.y + 5);
        _down = new Vector3(transform.position.x, transform.position.y -5);
    }
    void Update() {
        despawnTimer -= Time.deltaTime;

        if (despawnTimer <= 0) {
            Destroy(GetComponent<objectMovementScript>());
        }

        switch (moveWay) {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position,_right, 5 * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position,_left, 5 * Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position,_up, 5 * Time.deltaTime);
                break;
            case 4:
                transform.position = Vector3.MoveTowards(transform.position,_down, 5 * Time.deltaTime);
                break;
        }
    }
	void Raycasting() {

        rWay = Random.Range(rMoveNumbers[0], rMoveNumbers.Count);

        switch (rWay) {
            case 0:
                int howManyWidth = worldMakerScript.instance.width - 1;
                int reallyWidth = howManyWidth * worldMakerScript.instance.spaceBetweenObjectsX;

                if (transform.position.x == reallyWidth) {
                    rMoveNumbers.Remove(0);
                    Raycasting();
                }
                else {
                    RaycastHit2D _rightAbove = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y * 2), Vector2.right, 3f);
                    RaycastHit2D _rightMiddle = Physics2D.Raycast(transform.position, Vector2.right, 3f);
                    RaycastHit2D _rightUnder = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y * 2), Vector2.right, 3f);
                    Debug.Log("right");
                    if (_rightAbove.collider != null || _rightMiddle.collider != null || _rightUnder.collider != null) {
                        rMoveNumbers.Remove(0);
                        Raycasting();
                        Debug.Log(_rightAbove.collider);
                    }
                    else if (_rightAbove.collider == null && _rightMiddle.collider == null && _rightUnder.collider == null) {
                        moveWay = 1;
                    }
                }
                break;
            case 1:
                if (transform.position.x == 0) {
                    rMoveNumbers.Remove(1);
                    Raycasting();
                }
                else {
                    RaycastHit2D _leftAbove = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y * 2), Vector2.left, 3f);
                    RaycastHit2D _leftMiddle = Physics2D.Raycast(transform.position, Vector2.left, 3f);
                    RaycastHit2D _leftUnder = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y * 2), Vector2.left, 3f);
                    Debug.Log("left");
                    if (_leftAbove.collider != null || _leftMiddle.collider != null || _leftUnder.collider != null) {
                        rMoveNumbers.Remove(1);
                        Raycasting();
                        Debug.Log(_leftAbove.collider);
                    }
                    else if (_leftAbove.collider != null && _leftMiddle.collider != null && _leftUnder.collider != null) {
                        moveWay = 2;
                    }
                }
                break;
            case 2:
                if (transform.position.y == 0) {
                    rMoveNumbers.Remove(2);
                    Raycasting();
                }
                else {
                    RaycastHit2D _upAbove = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.y * 2, transform.position.y), Vector2.up, 5f);
                    RaycastHit2D _upMiddle = Physics2D.Raycast(transform.position, Vector2.up, 5f);
                    RaycastHit2D _upUnder = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.y * 2, transform.position.y), Vector2.up, 5f);
                    Debug.Log("up");
                    if (_upAbove.collider != null || _upMiddle.collider != null || _upUnder.collider != null) {
                        rMoveNumbers.Remove(2);
                        Raycasting();
                        Debug.Log(_upAbove.collider);
                    }
                    else if (_upAbove.collider == null && _upMiddle.collider == null && _upUnder.collider == null) {
                        moveWay = 3;
                    }
                }
                break;
            case 3:
                int howManyHeight = worldMakerScript.instance.height - 1;
                int reallyHeight = howManyHeight * worldMakerScript.instance.spaceBetweenObjectsY;

                if (transform.position.y == reallyHeight) {
                    rMoveNumbers.Remove(3);
                    Raycasting();
                }
                else {
                    RaycastHit2D _downAbove = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.y * 2, transform.position.y), Vector2.down, 5f);
                    RaycastHit2D _downMiddle = Physics2D.Raycast(transform.position, Vector2.down, 5f);
                    RaycastHit2D _downUnder = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.y * 2, transform.position.y), Vector2.down, 5f);
                    Debug.Log("down");
                    if (_downAbove.collider != null || _downMiddle.collider != null || _downUnder.collider != null) {
                        rMoveNumbers.Remove(3);
                        Raycasting();
                        Debug.Log(_downAbove.collider);
                    }
                    else if (_downAbove.collider == null && _downMiddle.collider == null && _downUnder.collider == null) {
                        moveWay = 4;
                    }
                }
                break;
        }
	}
}
    