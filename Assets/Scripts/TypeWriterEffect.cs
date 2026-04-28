using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float typingSpeed = 0.1f;
    private string fullText;
    public AudioSource speakingAudio;

    private void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
      
        if (speakingAudio != null && speakingAudio.isPlaying)
        {
            speakingAudio.Stop();
        }
    }
}