using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public string _tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _tagTargetDetection)
        {
           detectedObjs.Add(collision);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _tagTargetDetection)
        {
           detectedObjs.Remove(collision);
        }
    }
}