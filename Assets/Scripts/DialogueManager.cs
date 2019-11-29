using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text nameTextQuestion;
    public Text dialogueTextQuestion;
    private Queue<string> sentences;
    public Animator animator;
    public GameObject QuestionBox;
    public GameObject DialogueBox;
    public Dialogue GoodAnswer;
    public Dialogue BadAnswer;
    private bool isQuestion;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && sentences.Count >= 0) {
            DisplayNextSentence();
        }
    }
    public void StartDialogue (Dialogue dialogue) {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>()) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>().enabled = false;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        isQuestion = dialogue.isQuestion;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log("sentences.Count: " + sentences.Count + "   IsQuestion: " + isQuestion);
        if (sentences.Count == 0 && isQuestion == true) {
            Debug.Log("La");
            QuestionBox.SetActive(true);
            nameTextQuestion.text = nameText.text;
            DialogueBox.SetActive(false);
            StopCoroutine(TypeSentence(sentence, dialogueTextQuestion));
            StartCoroutine(TypeSentence(sentence, dialogueTextQuestion));
        }
        else {
            Debug.Log("ici");
            StopCoroutine(TypeSentence(sentence, dialogueText));
            StartCoroutine(TypeSentence(sentence, dialogueText));
        }
        // dialogueText.text = sentence;
    }
    IEnumerator TypeSentence (string sentence, Text dialogueTextUI) {
        dialogueTextUI.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTextUI.text += letter;
            yield return null;   
        }
    }
    public void GoodResponse() {
        QuestionBox.SetActive(false);
        DialogueBox.SetActive(true);
        isQuestion = false;
        StartDialogue(GoodAnswer);
        GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().GainLife();
    }
    public void BadResponse() {
        QuestionBox.SetActive(false);
        DialogueBox.SetActive(true);
        isQuestion = false;
        StartDialogue(BadAnswer);
    }
    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>()) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>().enabled = true;
        }
    }
}
