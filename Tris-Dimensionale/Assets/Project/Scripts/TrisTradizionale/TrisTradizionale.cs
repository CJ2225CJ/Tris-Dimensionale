using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrisTradizionale : MonoBehaviour
{
    public Image x;
    public Image o;
    public Image blank;
    public int currentSimbolTurn = 0; // 0 = X 1 = O
    public int turnCounter;
    public int[] spacesIdentifier; // identificates the simbol inside the space
    public Button[] trisSpaces; // the 9 spaces of the tris 
    public bool firstTurnSimbol = false;
    public IEnumerator nextGameTimer;
    [SerializeField] private float nextRoundTime = 5f;
    [SerializeField] private WinDisplayer WD;

    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        WD.turnIndicatorSprite[0].SetActive(true);
        WD.turnIndicatorSprite[1].SetActive(false);
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            trisSpaces[i].interactable = true;
            trisSpaces[i].GetComponent<Image>().sprite = x.sprite;
        }
        for (int i = 0; i < spacesIdentifier.Length; i++)
        {
            spacesIdentifier[i] = -100;
        }
    }

    public void TrisButtons(int nunber)
    {
        trisSpaces[nunber].image.sprite = WD.simbolsSprite[currentSimbolTurn];
        trisSpaces[nunber].interactable = false;

        spacesIdentifier[nunber] = currentSimbolTurn + 1;
        turnCounter++;

        if (turnCounter > 4)
        {
            WD.WinCecker();
        }
        if (currentSimbolTurn == 0)
        {
            for (int i = 0; i < trisSpaces.Length; i++)
            {
                if (trisSpaces[i].interactable == true)
                {
                    trisSpaces[i].GetComponent<Image>().sprite = o.sprite;
                }
            }
            currentSimbolTurn = 1;
            WD.turnIndicatorSprite[0].SetActive(false);
            WD.turnIndicatorSprite[1].SetActive(true);
        }
        else
        {
            for (int i = 0; i < trisSpaces.Length; i++)
            {
                if (trisSpaces[i].interactable == true)
                {
                    trisSpaces[i].GetComponent<Image>().sprite = x.sprite;
                }
            }
            currentSimbolTurn = 0;
            WD.turnIndicatorSprite[0].SetActive(true);
            WD.turnIndicatorSprite[1].SetActive(false);
        }
    }
}
