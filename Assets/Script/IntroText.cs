using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite cg;
    //public Color textColor; 
    public Font textFont;      
    public FontStyle fontStyle; 
    public int fontSize;        
}

public class IntroText : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private int count = 0;
    [SerializeField] private Dialogue[] dialogue;

    void Start()
    {
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        isDialogue = true;
        NextDialogue();
    }

    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;

        //txt_Dialogue.color = dialogue[count].textColor; 
        txt_Dialogue.font = dialogue[count].textFont; 
        txt_Dialogue.fontStyle = dialogue[count].fontStyle; 

        
        count++;
    }
    private void PreviousDialogue()
    {
        count = Mathf.Max(0, count - 2); 
        NextDialogue();
    }

    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                {
                    //Scene 1
                    if (SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "Scene 1-3" || SceneManager.GetActiveScene().name == "Scene 2-4" || SceneManager.GetActiveScene().name == "Scene 3-4")
                    {
                        SceneManager.LoadScene("Menu2");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 1-1")
                    {
                        SceneManager.LoadScene("Scene 1-2");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 1-2")
                    {
                        SceneManager.LoadScene("Scene 1-3");
                    }
                    
                    //Scene 2
                    else if (SceneManager.GetActiveScene().name == "Scene 2-1")
                    {
                        SceneManager.LoadScene("Scene 2-2");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 2-2")
                    {
                        SceneManager.LoadScene("Scene 2-3");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 2-3")
                    {
                        SceneManager.LoadScene("Scene 2-4");
                    }

                    //Scene 3
                    else if (SceneManager.GetActiveScene().name == "Scene 3-1")
                    {
                        SceneManager.LoadScene("Scene 3-2");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 3-2")
                    {
                        SceneManager.LoadScene("Scene 3-3");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 3-3")
                    {
                        SceneManager.LoadScene("Scene 3-4");
                    }
                    
                    //Scene 4
                    else if (SceneManager.GetActiveScene().name == "Scene 4-1")
                    {
                        SceneManager.LoadScene("Scene 4-2");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 4-2")
                    {
                        SceneManager.LoadScene("Scene 4-3");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 4-3")
                    {
                        SceneManager.LoadScene("Scene 4-4");
                    }
                    else if (SceneManager.GetActiveScene().name == "Scene 4-4")
                    {
                        SceneManager.LoadScene("Scene 4-5");
                    }
                    
                    //Last Scene
                    else if (SceneManager.GetActiveScene().name == "Scene 4-5")
                    {
                        SceneManager.LoadScene("Menu1");
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetMouseButtonDown(1))
            {
               
                PreviousDialogue();
            }
        }
    }
}

