using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.scores++;
            if (GameManager.Instance.scores % 5 == 0){
                Player.Instance.speed += 2f;
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "RaoChan")  
        {
            Destroy(gameObject);
        }
    }
}
