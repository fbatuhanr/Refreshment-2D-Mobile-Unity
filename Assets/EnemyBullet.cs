using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.name == "TheBall"){
            Destroy(other.gameObject);
        }
    }
}
