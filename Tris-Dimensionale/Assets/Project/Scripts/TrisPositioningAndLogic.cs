using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrisPositioningAndLogic : MonoBehaviour
{
    public int currentSimbolTurn = 0; // 0 = x 1 = o
    public int turnCounter;
    [SerializeField] private GameObject xSimbolPrefab;
    [SerializeField] private GameObject oSimbolPrefab;
    public GameObject[] slots;
    public GameObject currentSymbol;
    public int currentFlore = 0;
    public TextMeshProUGUI FlorText;

    public Symbol empty;
    public Symbol X3D;
    public Symbol O3D;
    public Slot3D[] slot3D;
    //WinLines
    public GameObject[] HorizontalWinLines;
    public GameObject[] VerticalWinLines;
    public GameObject[] HorizontalWinLinesDiagonal;
    public GameObject[] VerticalDiagonalWinLinesF;
    public GameObject[] VerticalDiagonalWinLinesR;
    public GameObject[] VerticalDiagonalWinLinesB;
    public GameObject[] VerticalDiagonalWinLinesL;
    public GameObject[] HorizontalDiagonalWinLinesFR;
    public GameObject[] HorizontalDiagonalWinLinesFL;
    public GameObject[] DiagonalMultiPlane;
    //UI
    [SerializeField] public GameObject[] selectedSimbol;
    public Sprite[] simbolsSprite; // 0 = X 1 = O
    public Button[] trisSpaces;
    public int nunber;
    public GameObject[] turnIndicatorSprite;
    public Image x2D;
    public Image o2D;
    public TextMeshProUGUI xScoreText;
    public TextMeshProUGUI oScoreText;
    public int xScore;
    public int oScore;
    public GameObject xWinSprite;
    public GameObject oWinSprite;
    public GameObject xDrawOSprite;
    public Image blank;
    public float nextRoundTime = 5f;
    public IEnumerator nextGameTimer;
    public bool firstTurnSimbol = false;


    bool monoTriggetBool = false; // to chaing int for mono update input
    public int i = 1; // to chaing int for mono update input
    //test
    //public Symbol[] symols;// can be useful
    public GameObject winLine;

    void Start()
    {
        GameSetup();
        UISetup();
    }

    void MonoInput(int i)
    {
        if (Input.anyKeyDown && !monoTriggetBool)
        {
            monoTriggetBool = true;
            Positioning(slot3D);
            OnFloreChainge(slot3D);
            KeyBindFlorUpDown();
        }

        if (!Input.anyKey)
        {
            monoTriggetBool = false;
        }
        //int p = 0;
        //if (i == 0)
        //{
        //    i = 1;
        //    if (Input.anyKey)
        //    {
        //        Positioning(slot3D);
        //        OnFloreChainge(slot3D);
        //    }
        //}
        //else
        //{
        //    i = 0;
        //}
    }

    public void Positioning(Slot3D[] slot3D)
    {

        int f = currentFlore * 9; // f means flor
        if (currentSimbolTurn == 0)
        {
            currentSymbol = xSimbolPrefab;
        }
        else
        {
            currentSymbol = oSimbolPrefab;
        }
        for (int s = 0; s < 9; s++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1 + s)) // make the UI wark
            {
                Slot3D slot = slots[s + f].GetComponent<Slot3D>();
                if (slot.GetSymbolType() == Symbol.Type.empty)
                {
                    Transform p = slots[s + f].transform;
                    if (currentSimbolTurn == 0)
                    {
                        slot3D[s + f].InstantiateSymbol(X3D);
                        Slot3D.Instantiate(currentSymbol, slots[s + f].transform);
                        currentSimbolTurn = 1;
                    }
                    else
                    {
                        slot3D[s + f].InstantiateSymbol(O3D);
                        Slot3D.Instantiate(currentSymbol, slots[s + f].transform);
                        currentSimbolTurn = 0;
                    }
                    turnCounter++;
                }
                else
                {
                    Debug.Log("slot occupato");
                }
            }
        }
        if (turnCounter > 4)
        {
            WinChecker(slot3D);
        }
    }
    //UI
    public void UISetup()
    {
        turnIndicatorSprite[0].SetActive(true);
        turnIndicatorSprite[1].SetActive(false);
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            trisSpaces[i].interactable = true;
            trisSpaces[i].GetComponent<Image>().sprite = x2D.sprite;
        }
    }
    public void UIButtons(int nunber)
    {
        //int tb = tbn;  // tb means UI tris buttons
        trisSpaces[nunber].image.sprite = simbolsSprite[currentSimbolTurn];
        trisSpaces[nunber].interactable = false;

        int f = currentFlore * 9; // f means flor
        if (currentSimbolTurn == 0)
        {
            currentSymbol = xSimbolPrefab;
        }
        else
        {
            currentSymbol = oSimbolPrefab;
        }

        Slot3D slot = slots[nunber + f].GetComponent<Slot3D>();
        if (slot.GetSymbolType() == Symbol.Type.empty)
        {
            Transform p = slots[nunber + f].transform;
            if (currentSimbolTurn == 0)
            {
                for (int i = 0; i < trisSpaces.Length; i++)
                {
                    if (trisSpaces[i].interactable == true)
                    {
                        trisSpaces[i].GetComponent<Image>().sprite = o2D.sprite;
                    }
                }
                turnIndicatorSprite[0].SetActive(false);
                turnIndicatorSprite[1].SetActive(true);
                slot3D[nunber + f].InstantiateSymbol(X3D);
                Slot3D.Instantiate(currentSymbol, slots[nunber + f].transform);
                currentSimbolTurn = 1;
            }
            else
            {
                for (int i = 0; i < trisSpaces.Length; i++)
                {
                    if (trisSpaces[i].interactable == true)
                    {
                        trisSpaces[i].GetComponent<Image>().sprite = x2D.sprite;
                    }
                }
                turnIndicatorSprite[0].SetActive(true);
                turnIndicatorSprite[1].SetActive(false);
                slot3D[nunber + f].InstantiateSymbol(O3D);
                Slot3D.Instantiate(currentSymbol, slots[nunber + f].transform);
                currentSimbolTurn = 0;
            }
            turnCounter++;
        }
        else
        {
            Debug.Log("slot occupato");
        }
    }

    public void OnFloreChainge(Slot3D[] slot3D)
    {
        int f = currentFlore * 9; // f means flor
        for (int i = 0; i < 9; i++)
        {
            Button button = trisSpaces[i];
            Image image = button.GetComponent<Image>();
            Slot3D slot = slots[i + f].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.X)
            {
                button.interactable = false;
                image.sprite = x2D.sprite;
            }
            if (slot.GetSymbolType() == Symbol.Type.O)
            {
                button.interactable = false;
                image.sprite = o2D.sprite;
            }
            if (slot.GetSymbolType() == Symbol.Type.empty && currentSimbolTurn == 0)
            {
                turnIndicatorSprite[0].SetActive(true);
                turnIndicatorSprite[1].SetActive(false);
                button.interactable = true;
                image.sprite = x2D.sprite;
            }
            if (slot.GetSymbolType() == Symbol.Type.empty && currentSimbolTurn == 1)
            {
                turnIndicatorSprite[0].SetActive(false);
                turnIndicatorSprite[1].SetActive(true);
                button.interactable = true;
                image.sprite = o2D.sprite;
            }
        }
    }

    public void FlorUp()
    {
        if (currentFlore < 2)
        {
            currentFlore++;
            FlorText.text = currentFlore.ToString();
            OnFloreChainge(slot3D);
        }
    }

    public void FlorDown()
    {
        if (currentFlore > 0)
        {
            currentFlore--;
            FlorText.text = currentFlore.ToString();
            OnFloreChainge(slot3D);
        }
    }

    public void KeyBindFlorUpDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FlorUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FlorDown();
        }
    }
    public void UIButton1() // tbn means tris button nunmer
    {
        UIButtons(nunber = 0);
        WinChecker(slot3D);
    }
    public void UIButton2()
    {
        UIButtons(nunber = 1);
        WinChecker(slot3D);
    }
    public void UIButton3()
    {
        UIButtons(nunber = 2);
        WinChecker(slot3D);
    }
    public void UIButton4()
    {
        UIButtons(nunber = 3);
        WinChecker(slot3D);
    }
    public void UIButton5()
    {
        UIButtons(nunber = 4);
        WinChecker(slot3D);
    }
    public void UIButton6()
    {
        UIButtons(nunber = 5);
        WinChecker(slot3D);
    }
    public void UIButton7()
    {
        UIButtons(nunber = 6);
        WinChecker(slot3D);
    }
    public void UIButton8()
    {
        UIButtons(nunber = 7);
        WinChecker(slot3D);
    }
    public void UIButton9()
    {
        UIButtons(nunber = 8);
        WinChecker(slot3D);
    }

    void OnbutonPres() // can be useful
    {

    }

    private void GameSetup()//find a way // remember to set every slot to empty 
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            Slot3D slot = slots[i].GetComponent<Slot3D>();
            empty.GetComponent<Symbol>();
        }
    }

    private void NextGameSetup()//find a way // remember to set every slot to empty 
    {
        currentSimbolTurn = 1;
        turnCounter = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            foreach (Transform child in slots[i].transform)
            {
                Destroy(child.gameObject);
            }
        }
        for (int i = 0; i < 9; i++)
        {
            HorizontalWinLines[i].SetActive(false);
            VerticalWinLines[i].SetActive(false);
            HorizontalWinLinesDiagonal[i].SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            VerticalDiagonalWinLinesF[i].SetActive(false);
            VerticalDiagonalWinLinesR[i].SetActive(false);
            VerticalDiagonalWinLinesB[i].SetActive(false);
            VerticalDiagonalWinLinesL[i].SetActive(false);
            HorizontalDiagonalWinLinesFR[i].SetActive(false);
            HorizontalDiagonalWinLinesFL[i].SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            DiagonalMultiPlane[i].SetActive(false);
        }
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
        OnFloreChainge(slot3D);
    }

    // Update is called once per frame
    void Update()
    {
        MonoInput(i);
        OnFloreChainge(slot3D);
    }

    public void WinChecker(Slot3D[] slot3D)
    {
        for (int i = 0; i < 9; i++)// HorizontalWinLines
        {
            Slot3D WP1 = slots[0 + (i * 3)].GetComponent<Slot3D>();// WP1 means win  position 1
            Slot3D WP2 = slots[1 + (i * 3)].GetComponent<Slot3D>();// WP2 means win  position 2
            Slot3D WP3 = slots[2 + (i * 3)].GetComponent<Slot3D>();// WP3 means win  position 3
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalWinLines[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalWinLines[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 9; i++)// HorizontalWinLinesDiagonal
        {
            int p = 0;
            if (i >= 3)
            {
                p = 6;
            }
            if (i >= 6)
            {
                p = 12;
            }
            Slot3D WP1 = slots[0 + i + p].GetComponent<Slot3D>();
            Slot3D WP2 = slots[3 + i + p].GetComponent<Slot3D>();
            Slot3D WP3 = slots[6 + i + p].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalWinLinesDiagonal[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalWinLinesDiagonal[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 9; i++)// VerticalWinLines
        {
            Slot3D WP1 = slots[0 + i].GetComponent<Slot3D>();
            Slot3D WP2 = slots[9 + i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[18 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalWinLines[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalWinLines[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesF
        {
            Slot3D WP1 = slots[0 + i].GetComponent<Slot3D>();
            Slot3D WP2 = slots[12 + i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[24 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesR
        {
            Slot3D WP1 = slots[6 - (i * 3)].GetComponent<Slot3D>();
            Slot3D WP2 = slots[16 - (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[26 - (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesB
        {
            Slot3D WP1 = slots[8 - i].GetComponent<Slot3D>();
            Slot3D WP2 = slots[14 - i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[20 - i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = slots[2 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP2 = slots[10 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[18 + (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 4; i++)// DiagonalMultiPlane
        {
            int p = 0;
            if (i >= 2)
            {
                p = 10;
            }
            Slot3D WP1 = slots[0 + (i * 6 - p)].GetComponent<Slot3D>();
            Slot3D WP2 = slots[13].GetComponent<Slot3D>();
            Slot3D WP3 = slots[26 - (i * 6 - p)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                DiagonalMultiPlane[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                DiagonalMultiPlane[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = slots[0 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP2 = slots[4 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[8 + (i * 9)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalDiagonalWinLinesFR[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalDiagonalWinLinesFR[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = slots[2 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP2 = slots[4 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[6 + (i * 9)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalDiagonalWinLinesFL[i].SetActive(true);
                WinDisplay();
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalDiagonalWinLinesFL[i].SetActive(true);
                WinDisplay();
                return;
            }
        }
    }
    public void WinDisplay()
    {
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            if (trisSpaces[i].interactable == true)
            {
                trisSpaces[i].GetComponent<Image>().sprite = blank.sprite;
            }
        }
        if (currentSimbolTurn == 1)
        {
            xScore++;
            xScoreText.text = xScore.ToString();
            xWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        else if (currentSimbolTurn == 0)
        {
            oScore++;
            oScoreText.text = oScore.ToString();
            oWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
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
        oWinSprite.SetActive(false);
        xWinSprite.SetActive(false);
    }
}
