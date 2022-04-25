using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FortuneFarmer;

public class PlayerCollider : MonoBehaviour
{
    MinigameController mc;

    void Start()
    {
        mc = transform.parent.parent.GetComponent<MinigameController>();
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Rock"){
            Debug.Log("Hello");
            Destroy(target.gameObject);
            mc.GameOver();
        }

        if (target.tag == "Apple"){
            Destroy(target.gameObject);
            mc.updateScore();
        }

    }
}
