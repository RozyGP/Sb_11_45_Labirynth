using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public Transform openPosition;
    public Transform closePosition;

    public float speed = 1f;
    public bool open = false;

    private void Update()
    {
        if(open)
        {
            door.position = Vector3.MoveTowards(
                door.position,
                openPosition.position,
                Time.deltaTime * speed
                );
        }

        if (!open)
        {
            door.position = Vector3.MoveTowards(
                door.position,
                closePosition.position,
                Time.deltaTime * speed
                );
        }
    }

    public void CloseOpen()
    {
        open = !open;
    }
}
