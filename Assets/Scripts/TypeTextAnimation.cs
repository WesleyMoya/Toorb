using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypeTextAnimation : MonoBehaviour {

    public Action TypeFinished;
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    public string fullText;
    Coroutine coroutine;

    public void StartTyping() {
        coroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText() {

        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for(int i = 0; i <= textObject.text.Length; i++) {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        TypeFinished?.Invoke();

    }

    public void Skip() {

        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;

    }
}