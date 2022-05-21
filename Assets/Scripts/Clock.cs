using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime; //true - dodaje czas, false - odejmuje czas
    public int time = 5;

    public override void Picked()
    {
        if(addTime)
            GameManager.gameManager.AddTime(time);
        else
            GameManager.gameManager.AddTime(time*(-1));
        GameManager.gameManager.PlayClip(pickedClip);
        Destroy(this.gameObject);
    }
}
