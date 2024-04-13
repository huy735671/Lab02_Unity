using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject gameOverWindow;
    private Transform canvas;
    public int row;
    public int colum;
    private Board board;

    public Sprite xSprite;
    public Sprite oSprite;
    private Image Image;
    private Button button;
    
    private void Awake()
    {
        Image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Onclick);


    }


    private void Start()
    {
        board = FindObjectOfType<Board>();
        canvas = FindObjectOfType<Canvas>().transform;
    }
    public void ChangeImage(string s)
    {
        if(s=="x")
        {
            Image.sprite = xSprite;
        }
        else{
            Image.sprite = oSprite;
        }
    }

    public void Onclick()
    {
        ChangeImage(board.currentTurn);
        if(board.Check(this.row, this.colum))
        {
            GameObject window= Instantiate(gameOverWindow, canvas);
            window.GetComponent<GameOverWindow>().SetName(board.currentTurn);
        }
        if(board.currentTurn =="x")
        {
            board.currentTurn ="o";
        }
        else
        {
            board.currentTurn = "x";
        }
    }
}
