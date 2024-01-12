using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollectible : MonoBehaviour, IScoreAddition
{
    public int ScoreAdded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        CollectibleBehaviour();
    }
    public void ScoreAddition()
    {
        GameManager.Instance.Score += ScoreAdded;
    }

    virtual public void CollectibleBehaviour()
    {
        Handheld.Vibrate();

        ScoreAddition();
        Destroy(gameObject, 1.5f);
    }

}
