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
    //test
    //public Symbol[] symols;// can be useful
    public GameObject winLine;

    void Start()
    {
        GameSetup();
        UISetup();
    }

    void OnInput()
    {
        if (Input.anyKey)
        {
            Positioning(slot3D);
        }
    }

    public void Positioning(Slot3D[] slot3D)
    {
        if (turnCounter > 4)
        {
            WinChecker(slot3D);
        }
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
    }
    public void UIButton2()
    {
        UIButtons(nunber = 1);
    }
    public void UIButton3()
    {
        UIButtons(nunber = 2);
    }
    public void UIButton4()
    {
        UIButtons(nunber = 3);
    }
    public void UIButton5()
    {
        UIButtons(nunber = 4);
    }
    public void UIButton6()
    {
        UIButtons(nunber = 5);
    }
    public void UIButton7()
    {
        UIButtons(nunber = 6);
    }
    public void UIButton8()
    {
        UIButtons(nunber = 7);
    }
    public void UIButton9()
    {
        UIButtons(nunber = 8);
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

    // Update is called once per frame
    void Update()
    {
        OnInput();
        KeyBindFlorUpDown();
    }

    public void WinChecker(Slot3D[] slot3D)
    {
        for (int i = 0; i < 9; i++)// Horizontal
        {
            Slot3D WP1 = slots[0 + (i * 3)].GetComponent<Slot3D>();// WP1 means win  position 1
            Slot3D WP2 = slots[1 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[2 + (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalWinLines[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalWinLines[i].SetActive(true);
                return;
            }
        }
        for (int i = 0; i < 9; i++)// Vertical
        {
            Slot3D WP1 = slots[0 + i].GetComponent<Slot3D>();// WHP1 means win horizontal position 1
            Slot3D WP2 = slots[9 + i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[18 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalWinLines[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalWinLines[i].SetActive(true);
                return;
            }
        }
        for (int i = 0; i < 3; i++)// Diagonal Forront
        {
            Slot3D WP1 = slots[0 + i].GetComponent<Slot3D>();// WP1 means win  position 1
            Slot3D WP2 = slots[12 + i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[24 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                return;
            }
        }
        for (int i = 0; i < 3; i++)// Diagonal Rigt NOT EZ
        {
            Slot3D WP1 = slots[6 - (i * 3)].GetComponent<Slot3D>();// WHP1 means win horizontal position 1
            Slot3D WP2 = slots[16 - (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[26 - (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                return;
            }
        }
        for (int i = 0; i < 3; i++)// Diagonal Back
        {
            Slot3D WP1 = slots[8 - i].GetComponent<Slot3D>();// WP1 means win  position 1
            Slot3D WP2 = slots[14 - i].GetComponent<Slot3D>();
            Slot3D WP3 = slots[20 - i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                return;
            }
        }
        for (int i = 0; i < 3; i++)// Diagonal Rigt NOT EZ
        {
            Slot3D WP1 = slots[2 + (i * 3)].GetComponent<Slot3D>();// WHP1 means win horizontal position 1
            Slot3D WP2 = slots[10 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = slots[18 + (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                return;
            }
        }
        //int WHB = spacesIdentifier[0] + spacesIdentifier[1] + spacesIdentifier[2]; // W means win H means horizontal
        //int WHM = spacesIdentifier[3] + spacesIdentifier[4] + spacesIdentifier[5]; // B means botom M means midle T means top
        //int WHT = spacesIdentifier[6] + spacesIdentifier[7] + spacesIdentifier[8]; // L means left R means rigt

        //for (int i = 0; i < 3; i++)
        //{
        //    int WV = spacesIdentifier[0 + i] + spacesIdentifier[3 + i] + spacesIdentifier[6 + i];// V means vertical
        //    for (int y = 0; y < WV; y++)
        //    {
        //        if (WV == 3 * (currentSimbolTurn + 1))
        //        {
        //            WinDisplay(i + 3);
        //            return;
        //        }
        //    }
        //}

        ////int WVL = spacesIdentifier[0] + spacesIdentifier[3] + spacesIdentifier[6]; // V means vertical
        ////int WVM = spacesIdentifier[1] + spacesIdentifier[4] + spacesIdentifier[7];
        ////int WVR = spacesIdentifier[2] + spacesIdentifier[5] + spacesIdentifier[8];

        //for (int i = 0; i < 2; i++)
        //{
        //    int WD = spacesIdentifier[0 + i + i] + spacesIdentifier[4] + spacesIdentifier[8 - i - i];// D means diagonal
        //    for (int y = 0; y < WD; y++)
        //    {
        //        if (WD == 3 * (currentSimbolTurn + 1))
        //        {
        //            WinDisplay(i + 6);
        //            return;
        //        }
        //    }
        //}

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
        //if (turnCounter == 9)
        //{
        //    xDrawOSprite.gameObject.SetActive(true);
        //    StartCoroutine(NextGameTimer(nextRoundTime));
        //}
    }
}
