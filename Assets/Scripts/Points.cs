using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    AudioSource audion;

    private void Awake()
    {
        audion = GetComponent<AudioSource>();
        _text.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas")) 
        {
            audion.Play();
            Destroy(other.gameObject);
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
}
    }
}
