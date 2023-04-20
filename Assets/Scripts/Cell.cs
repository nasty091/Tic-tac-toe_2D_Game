using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject gameOverWindow;
    private Transform canvas;

    public int row;
    public int column;

    private Board board;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private Button button;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        //Find the Object has the script whose name is Board
        //Declare board in Start not Awake because we don't sure that the board exists
        board = GameObject.FindObjectOfType<Board>();
        canvas = FindObjectOfType<Canvas>().transform;
    }

    public void ChangeImage(string s)
    {
        if(s == "x")
        {
            image.sprite = xSprite;
        }
        else
        {
            image.sprite = oSprite;
        }

    }

    public void OnClick()
    {
        ChangeImage(board.currentTurn);
        if(board.Check(this.row, this.column))
        {
            GameObject window = Instantiate(gameOverWindow, canvas);
            window.GetComponent<GameOver>().SetName("The winner is: " + board.currentTurn);
        }

        if(board.currentTurn == "x")
        {
            board.currentTurn = "o";
        }
        else
        {
            board.currentTurn = "x";
        }
    }
}
