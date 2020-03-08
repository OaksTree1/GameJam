using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue;

    public CutScenePlayer CutScenePlayer;

    public Text TheText;
    public TextAsset TextContainer;
    public string[] LinesofText;

    public int currentline;
    public int endline;

    private bool IsTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;


    public bool IsActive;

    public int TextMoveTime;

    private bool AutoScroll;



    // Start is called before the first frame update
    void Start()
    {

        CutScenePlayer = FindObjectOfType<CutScenePlayer>();

        if (TextContainer != null)
        {
            LinesofText = TextContainer.text.Split('\n');
        }

        if (endline == 0)
        {
            endline = LinesofText.Length - 1;
        }
        if (IsActive)
        {
            ReloadScript(TextContainer);
        }
        else
        {
            TextBoxDisable();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsActive)
        {
            return;
        }

        if (!IsTyping)
        {
            new WaitForSeconds(TextMoveTime);

            currentline += 1;

            if (currentline > endline)
            {
                TextBoxDisable();
                TheText.text = "";
                CutScenePlayer.Stop = false;
            }
            else
            {
                StartCoroutine(ScrollText(LinesofText[currentline]));
            }
        }
        else if (IsTyping && !cancelTyping)
        {
            cancelTyping = true;
        }

    }

    private IEnumerator ScrollText(string Dalines)
    {
        int Letter = 0;
        Debug.Log("reached");
        TheText.text = "";
        IsTyping = true;
        cancelTyping = false;
        foreach (char letter in LinesofText[currentline])
        {
            TheText.text += letter;
            Letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        TheText.text = Dalines;
        IsTyping = false;
        cancelTyping = false;
    }

    public void TextBoxDisable()
    {
        dialogue.SetActive(false);
        IsActive = false;

    }

    public void ReloadScript(TextAsset text)
    {
        dialogue.SetActive(true);
        IsActive = true;

        if (text != null)
        {
            LinesofText = new string[1];
            LinesofText = text.text.Split('\n');
        }
    }
}
