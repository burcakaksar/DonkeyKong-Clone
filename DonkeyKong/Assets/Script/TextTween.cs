using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTween : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;


    void Start()
    {
        levelText.text = "Level " + CountScript.instance.level.ToString(); 

        Sequence muSequence = DOTween.Sequence();
        muSequence.Append(transform.DOScale(new Vector3(2, 2, 1), 1.5f));
        muSequence.Append(transform.DOScale(new Vector3(0, 0, 1), 1.5f));
        muSequence.OnComplete(DestroyText);

    }

    private void DestroyText()
    {
        Destroy(levelText.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
