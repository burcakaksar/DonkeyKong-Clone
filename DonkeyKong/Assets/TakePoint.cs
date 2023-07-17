using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TakePoint : MonoBehaviour
{
    [SerializeField] GameObject points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel") || collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(points, collision.transform.position, Quaternion.identity);
        }
    }
}
