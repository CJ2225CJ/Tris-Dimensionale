using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinDisplayer : MonoBehaviour
{
    public Sprite[] simbolsSprite; // 0 = X 1 = O
    public GameObject[] turnIndicatorSprite; // idicats the current simbol turn
    [SerializeField] private GameObject xWinSprite;
    [SerializeField] private GameObject oWinSprite;
    [SerializeField] private GameObject xDrawOSprite;
    [SerializeField] private TextMeshProUGUI xScoreText;
    [SerializeField] private TextMeshProUGUI oScoreText;
    [SerializeField] private float nextRoundTime = 5f;
    [SerializeField] private int xScore;
    [SerializeField] private int oScore;
    [SerializeField] private GameObject[] winLines;
    private IEnumerator nextGameTimer;
    [SerializeField] private TrisTradizionale TT;
    public void WinCecker() // optimazation for loop that ads changes the nominal valew of the arrays.
    {
        for (int i = 0; i < 3; i++)
        {
            int WH = TT.spacesIdentifier[0 + (i * 3)] + TT.spacesIdentifier[1 + (i * 3)] + TT.spacesIdentifier[2 + (i * 3)];// W means win H means horizontal
            if (WH == 3 * (TT.currentSimbolTurn + 1))
            {
                WinDisplay(i);
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            int WV = TT.spacesIdentifier[0 + i] + TT.spacesIdentifier[3 + i] + TT.spacesIdentifier[6 + i];// V means vertical

            if (WV == 3 * (TT.currentSimbolTurn + 1))
            {
                WinDisplay(i + 3);
                return;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            int WD = TT.spacesIdentifier[0 + i + i] + TT.spacesIdentifier[4] + TT.spacesIdentifier[8 - i - i];// D means diagonal

            if (WD == 3 * (TT.currentSimbolTurn + 1))
            {
                WinDisplay(i + 6);
                return;
            }
        }
        if (TT.turnCounter == 9)
        {
            xDrawOSprite.gameObject.SetActive(true);
            StartCoroutine(NextGameTimer(nextRoundTime));
        }
    }
    public void WinDisplay(int indexIn)
    {
        for (int i = 0; i < TT.trisSpaces.Length; i++)
        {
            if (TT.trisSpaces[i].interactable == true)
            {
                TT.trisSpaces[i].GetComponent<Image>().sprite = TT.blank.sprite;
            }
        }
        if (TT.currentSimbolTurn == 0)
        {
            xScore++;
            xScoreText.text = xScore.ToString();
            xWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        else if (TT.currentSimbolTurn == 1)
        {
            oScore++;
            oScoreText.text = oScore.ToString();
            oWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        winLines[indexIn].SetActive(true);
        for (int i = 0; i < TT.trisSpaces.Length; i++)
        {
            TT.trisSpaces[i].interactable = false;
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
    void NextGameSetup()
    {
        TT.turnCounter = 0;
        for (int i = 0; i < TT.trisSpaces.Length; i++)
        {
            TT.trisSpaces[i].interactable = true;
            if (TT.firstTurnSimbol == false)
            {
                TT.trisSpaces[i].GetComponent<Image>().sprite = TT.o.sprite;
            }
            else
            {
                TT.trisSpaces[i].GetComponent<Image>().sprite = TT.x.sprite;
            }
        }
        if (TT.firstTurnSimbol == false)
        {
            TT.currentSimbolTurn = 1;
            turnIndicatorSprite[0].SetActive(false);
            turnIndicatorSprite[1].SetActive(true);
            TT.firstTurnSimbol = true;
        }
        else
        {
            TT.currentSimbolTurn = 0;
            turnIndicatorSprite[0].SetActive(true);
            turnIndicatorSprite[1].SetActive(false);
            TT.firstTurnSimbol = false;
        }
        for (int i = 0; i < TT.spacesIdentifier.Length; i++)
        {
            TT.spacesIdentifier[i] = -100;
        }
        xDrawOSprite.SetActive(false);
    }
}
