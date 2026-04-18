using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrisTradizionale : MonoBehaviour
{
    public Image x;
    public Image o;
    public Image blank;
    public int currentSimbolTurn = 0; // 0 = X 1 = O
    public int turnCounter;
    public int xScore;
    public int oScore;
    public int[] spacesIdentifier; // identificates the simbol inside the space
    public GameObject[] turnIndicatorSprite; // idicats the current simbol turn
    public GameObject[] winLines;
    public GameObject xWinSprite;
    public GameObject oWinSprite;
    public GameObject xDrawOSprite;
    public Button[] trisSpaces; // the 9 spaces of the tris 
    public Sprite[] simbolsSprite; // 0 = X 1 = O
    public TextMeshProUGUI xScoreText;
    public TextMeshProUGUI oScoreText;
    public float nextRoundTime = 5f;
    public bool firstTurnSimbol = false;
    public IEnumerator nextGameTimer;

    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        turnIndicatorSprite[0].SetActive(true);
        turnIndicatorSprite[1].SetActive(false);
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
    void NextGameSetup() // optimize 
    {
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            trisSpaces[i].interactable = true;
            if(firstTurnSimbol == false)
            {
                trisSpaces[i].GetComponent<Image>().sprite = o.sprite;
            }
            else
            {
                trisSpaces[i].GetComponent<Image>().sprite = x.sprite;
            }   
        }
        turnCounter = 0;
        if (firstTurnSimbol == false)
        {
            currentSimbolTurn = 1;
            turnIndicatorSprite[0].SetActive(false);
            turnIndicatorSprite[1].SetActive(true);
            firstTurnSimbol = true;
        }
        else
        {
            currentSimbolTurn = 0;
            turnIndicatorSprite[0].SetActive(true);
            turnIndicatorSprite[1].SetActive(false);
            firstTurnSimbol = false;
        }

        for (int i = 0; i < spacesIdentifier.Length; i++)
        {
            spacesIdentifier[i] = -100;
        }
        xDrawOSprite.SetActive(false);
    }

    public void TrisButtons(int nunber)
    {
        trisSpaces[nunber].image.sprite = simbolsSprite[currentSimbolTurn];
        trisSpaces[nunber].interactable = false;

        spacesIdentifier[nunber] = currentSimbolTurn + 1;
        turnCounter++;

        if (turnCounter > 4)
        {
            WinCecker();
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
            turnIndicatorSprite[0].SetActive(false);
            turnIndicatorSprite[1].SetActive(true);
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
            turnIndicatorSprite[0].SetActive(true);
            turnIndicatorSprite[1].SetActive(false);
        }
    }
    void WinCecker() // optimazation for loop that ads changes the nominal valew of the arrays.
    {
        for (int i = 0; i < 3; i++)
        {
            int WH = spacesIdentifier[0 + (i * 3)] + spacesIdentifier[1 + (i * 3)] + spacesIdentifier[2 + (i * 3)];// W means win H means horizontal
            var winCondition = new int[] { WH };
            for (int y = 0; y < winCondition.Length; y++)
            {
                if (winCondition[y] == 3 * (currentSimbolTurn + 1))
                {
                    WinDisplay(i);
                    return;
                }
            }
        }

        //int WHB = spacesIdentifier[0] + spacesIdentifier[1] + spacesIdentifier[2]; // W means win H means horizontal
        //int WHM = spacesIdentifier[3] + spacesIdentifier[4] + spacesIdentifier[5]; // B means botom M means midle T means top
        //int WHT = spacesIdentifier[6] + spacesIdentifier[7] + spacesIdentifier[8]; // L means left R means rigt

        for (int i = 0; i < 3; i++)
        {
            int WV = spacesIdentifier[0 + i] + spacesIdentifier[3 + i] + spacesIdentifier[6 + i];// V means vertical
            var winCondition = new int[] { WV };// this is the problem
            for (int y = 0; y < winCondition.Length; y++)
            {
                if (winCondition[y] == 3 * (currentSimbolTurn + 1))
                {
                    WinDisplay(i + 3);
                    return;
                }
            }
        }

        //int WVL = spacesIdentifier[0] + spacesIdentifier[3] + spacesIdentifier[6]; // V means vertical
        //int WVM = spacesIdentifier[1] + spacesIdentifier[4] + spacesIdentifier[7];
        //int WVR = spacesIdentifier[2] + spacesIdentifier[5] + spacesIdentifier[8];

        for (int i = 0; i < 2; i++)
        {
            int WP = spacesIdentifier[0 + i + i] + spacesIdentifier[4] + spacesIdentifier[8 - i - i];// P means perpendicular
            var winCondition = new int[] { WP };
            for (int y = 0; y < winCondition.Length; y++)
            {
                if (winCondition[y] == 3 * (currentSimbolTurn + 1))
                {
                    WinDisplay(i + 6);
                    return;
                }
            }
        }

        //int WPR = spacesIdentifier[0] + spacesIdentifier[4] + spacesIdentifier[8]; // P means perpendicular
        //int WPL = spacesIdentifier[2] + spacesIdentifier[4] + spacesIdentifier[6];
        //var winCondition = new int[] { WH, WV, WP, };
        //for (int i = 0; i < winCondition.Length; i++)
        //{
        //    if (winCondition[i] == 3 * (currentSimbolTurn + 1))
        //    {
        //        WinDisplay(i);
        //        return;//???
        //    }
        //}

        //if (trisSpaces[0].interactable == false && trisSpaces[1].interactable == false && trisSpaces[2].interactable == false && trisSpaces[3].interactable == false && trisSpaces[4].interactable == false && trisSpaces[5].interactable == false && trisSpaces[6].interactable == false && trisSpaces[7].interactable == false && trisSpaces[8].interactable == false)
        //{
        //    xDrawOSprite.gameObject.SetActive(true);
        //    StartCoroutine(NextRound(nextRoundTime));
        //    // find a beter way to do this 
        //}
        if (turnCounter == 9)
        {
            xDrawOSprite.gameObject.SetActive(true);
            StartCoroutine(NextGameTimer(nextRoundTime));
        }
    }
    public void WinDisplay(int indexIn)
    {
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            if (trisSpaces[i].interactable == true)
            {
                trisSpaces[i].GetComponent<Image>().sprite = blank.sprite;
            }
        }
        if (currentSimbolTurn == 0)
        {
            xScore++;
            xScoreText.text = xScore.ToString();
            xWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        else if (currentSimbolTurn == 1)
        {
            oScore++;
            oScoreText.text = oScore.ToString();
            oWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        winLines[indexIn].SetActive(true);
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            trisSpaces[i].interactable = false;
        }
        StartCoroutine(NextGameTimer(nextRoundTime));
    }
    IEnumerator NextGameTimer(float nextRoundTime)
    {
        yield return new WaitForSeconds(nextRoundTime);
        NextGameSetup();
        for (int i = 0; i < winLines.Length; i++)
        {
            winLines[i].SetActive(false);
        }
        oWinSprite.SetActive(false);
        xWinSprite.SetActive(false);
    }
}
