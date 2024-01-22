using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollectible : MonoBehaviour
{
    public int LevelAdded;
    public int ScoreAdded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        CollectibleBehaviour();
    }

    virtual public void CollectibleBehaviour()
    {
        Handheld.Vibrate();
        Destroy(gameObject, 1.5f);
    }

}
