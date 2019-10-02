using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyFly : MonoBehaviour
{
    public void Fly()
    {
        this.transform.DOMove(Game.Me.ui.hudCoin.transform.position, 0.5f).OnComplete(Kill);
    }

    void Kill()
    {
        TrashMan.despawn(this.gameObject);
    }
}
