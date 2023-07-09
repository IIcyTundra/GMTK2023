using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueSystem:MonoBehaviour
{
    [Header("Dialogue")]
    public float dialogueSpeed = 0.03f;
    public string[] dialogue;
    public Sprite[] sprites;
    [Header("Objects")]
    public GameObject Left;
    public GameObject Right;
    public GameObject Protag;
    public GameObject Antag;
    public TMP_Text dialogueLeft;
    public TMP_Text dialogueRight;

    private int currentDialogue;
    private float protagX;
    private float antagX;
    void Start()
    {
        MusicManager.Instance.PlayTrack(MusicManager.Track.NonCombatTrack);
        if (Left == null)
            Left = GameObject.Find("Leftside");
        if (Right == null)
            Right = GameObject.Find("Rightside");
        if (Protag == null)
            Protag = GameObject.Find("CharLeft");
        if (Antag == null)
            Antag = GameObject.Find("CharRight");
        if (dialogueLeft == null)
            dialogueLeft = GameObject.Find("DialogueLeft").GetComponent<TMP_Text>();
        if (dialogueRight == null)
            dialogueRight = GameObject.Find("DialogueRight").GetComponent<TMP_Text>();

        protagX = Protag.GetComponent<RectTransform>().anchoredPosition.x;
        antagX = Antag.GetComponent<RectTransform>().anchoredPosition.x;
        StartCoroutine(TypeText());
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            //if (currentDialogue >= dialogue.Length)
            //    SceneManager.LoadScene("scene name");
            //else
                StartCoroutine(TypeText());
        }
    }

    IEnumerator CharacterFade(GameObject obj, float duration, float origin, float offset, int port)
    {
        RectTransform objTransform = obj.GetComponent<RectTransform>();
        Image objImage = obj.GetComponent<Image>();
        objImage.sprite = sprites[port];
        objTransform.anchoredPosition = new Vector3(origin + offset, objTransform.anchoredPosition.y, 0f);
        Color32 startColor = objImage.color;
        startColor = new Color32(startColor.r, startColor.g, startColor.b, (byte)0);
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            objTransform.anchoredPosition = new Vector3(Mathf.Lerp(objTransform.anchoredPosition.x, origin, timer / duration), objTransform.anchoredPosition.y, 0f);
            objImage.color = new Color32(startColor.r, startColor.g, startColor.b, (byte)Mathf.Lerp(startColor.a, 255, timer / duration));
            yield return null;
        }
    }

    IEnumerator TypeText()
    {
        string dialogueSplit = dialogue[currentDialogue];
        string currentText = "";
        bool rightside = false;
        int port = 0;
        if (dialogueSplit.Contains("^"))
        {
            rightside = dialogueSplit.Split("^")[0].ToLower() == "right";
            port = int.Parse(dialogueSplit.Split("^")[1]);
            dialogueSplit = dialogueSplit.Split("^")[2];
        }
        Right.SetActive(rightside);
        Left.SetActive(!rightside);
        StartCoroutine(CharacterFade(rightside ? Antag : Protag, 0.4f, rightside ? antagX : protagX, rightside ? 100 : -100, port));

        for (int i = 0; i < dialogueSplit.Length; i++)
        {
            currentText += dialogueSplit[i];
            if (rightside)
                dialogueRight.text = currentText;
            else
                dialogueLeft.text = currentText;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        currentDialogue++;
    }
}
