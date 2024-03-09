using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [HideInInspector] public Rigidbody _playerRb;
    public string SoundName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerRb = other.GetComponent<Rigidbody>();
            PanelBehaviour();
        }
    }

    virtual public void PanelBehaviour()
    {
        AudioManager.Instance.PlaySound(SoundName);
        
    }
}
