using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor keyColor;
    public override void Picked()
    {
        GameManager.gameManager.AddKey(keyColor);
        GameManager.gameManager.PlayClip(pickedClip);
        Destroy(this.gameObject);
    }
}
