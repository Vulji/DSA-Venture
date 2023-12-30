using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : BasicCollectible
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CollectibleBehaviour()
    {
        base.CollectibleBehaviour();
        GameManager.Instance.Score += 1000;
        Debug.Log(GameManager.Instance.Score);
    }
}
