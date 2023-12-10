using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class NPC : MonoBehaviour
{

    [SerializeField] GameObject dialogPanel;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] string[] dialog;
    private int index;


    [SerializeField]  GameObject contButton;
    [SerializeField] float wordSpeed;
    [SerializeField] bool playerIsClose;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogText.text == dialog[index])
        {
            contButton.SetActive(true);
        }
    }

    [SerializeField] void ZeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }


    IEnumerator Typing()
    {
        foreach(char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);


        if(index < dialog.Length - 1) 
        {

            index++;
            dialogText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            ZeroText();

        }



    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }



}
