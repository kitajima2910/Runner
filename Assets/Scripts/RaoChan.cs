using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaoChan : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Die();
        }
    }
}
