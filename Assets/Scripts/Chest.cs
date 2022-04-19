using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int goldAmount = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.gold += goldAmount;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + goldAmount + " gold!", 25, Color.yellow, transform.position, Vector3.up * 100, 3.0f);
        }
    }
}
