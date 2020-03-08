using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateText : MonoBehaviour
{

    public TextAsset InputText;
    public TextAsset InputTextBlank;

    public int startline;
    public int endline;

    public Dialogue dialogue;

    public bool RequireButtonPress;
    private bool WaitforPress;

    public bool IsCollison;

   
    public bool DestroyWhenFinished;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitforPress && Input.GetKeyDown(KeyCode.J))
        {
            dialogue.ReloadScript(InputText);
            dialogue.currentline = startline;
            dialogue.endline = endline;
            //TheTextBox.TextBoxEnable();

            if (DestroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(RequireButtonPress)
            {
                WaitforPress = true;
                return;
            }

            dialogue.ReloadScript(InputText);
            dialogue.currentline = startline;
            dialogue.endline = endline;
            //TheTextBox.TextBoxEnable();

            if(DestroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            dialogue.TextBoxDisable();
            dialogue.ReloadScript(InputTextBlank);
        }
    }
}
