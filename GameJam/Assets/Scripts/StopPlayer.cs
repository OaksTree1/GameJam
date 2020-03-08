using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    CutScenePlayer CutScenePlayer;
    Dialogue dialogue;

    public TextAsset InputText;
    public int startline;
    public int endline;

    // Start is called before the first frame update
    void Start()
    {
        CutScenePlayer = FindObjectOfType<CutScenePlayer>();
        dialogue = FindObjectOfType<Dialogue>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider)
        {
            if (collision.collider.name == "Player")
            {
                Debug.Log("huh");
                CutScenePlayer.Stop = true;

                dialogue.ReloadScript(InputText);
                dialogue.currentline = startline;
                dialogue.endline = endline;
                
                this.GetComponent<Collider2D>().enabled = false; 
            }

        }
    }
}
