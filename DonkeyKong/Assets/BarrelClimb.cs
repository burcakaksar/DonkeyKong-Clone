using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarrelClimb : MonoBehaviour
{
    [SerializeField] Transform TargetPosition2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Barrel newBarrel=collision.gameObject.GetComponent<Barrel>();
        Sequence mySequ = DOTween.Sequence();
        if (collision.gameObject.CompareTag("Barrel"))
        {
            float RandomValue=Random.Range(1,4);
            if (RandomValue==1)
            {

                if (newBarrel.rightWall && !newBarrel.leftWall)
                {
                    newBarrel.barrelSpeed = 0;
                    mySequ.Append(collision.gameObject.transform.DOMoveY(TargetPosition2.position.y, 0.5f).SetEase(Ease.Linear)).OnComplete(() => newBarrel.LeftSide());
                    StartCoroutine(BarrelLeft(newBarrel));
                    
                    
                }
                if (newBarrel.leftWall && !newBarrel.rightWall)
                {
                    newBarrel.barrelSpeed = 0;
                    mySequ.Append(collision.gameObject.transform.DOMoveY(TargetPosition2.position.y, 0.5f).SetEase(Ease.Linear)).OnComplete(() => newBarrel.RightSide());
                    StartCoroutine(BarrelLeft(newBarrel));
                }

            }
        }
    }

    IEnumerator BarrelLeft(Barrel barrel)
    {
        yield return new WaitForSeconds(.5f);
        barrel.barrelSpeed = 5;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
        Gizmos.DrawWireSphere(TargetPosition2.position, 0.25f);
    }

}
