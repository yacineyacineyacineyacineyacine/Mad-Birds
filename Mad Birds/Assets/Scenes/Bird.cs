using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 _initilaPosition;

    private void Awake()
    {
        _initilaPosition = transform.position;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directiontoInitialPosition = _initilaPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directiontoInitialPosition);
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
