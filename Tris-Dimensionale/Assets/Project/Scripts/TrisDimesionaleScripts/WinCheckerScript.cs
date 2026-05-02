using UnityEngine;

public class WinCheckerScript : MonoBehaviour
{
    public bool winState = false;
    private bool firstTurnSimbol = false;
    [SerializeField] private GameObject[] HorizontalWinLines;
    [SerializeField] private GameObject[] VerticalWinLines;
    [SerializeField] private GameObject[] HorizontalWinLinesDiagonal;
    [SerializeField] private GameObject[] VerticalDiagonalWinLinesF;
    [SerializeField] private GameObject[] VerticalDiagonalWinLinesR;
    [SerializeField] private GameObject[] VerticalDiagonalWinLinesB;
    [SerializeField] private GameObject[] VerticalDiagonalWinLinesL;
    [SerializeField] private GameObject[] HorizontalDiagonalWinLinesFR;
    [SerializeField] private GameObject[] HorizontalDiagonalWinLinesFL;
    [SerializeField] private GameObject[] DiagonalMultiPlane;
    
    [SerializeField] private TrisPositioningAndLogic TPaL;
    [SerializeField] private UITD UITD;
    [SerializeField] private Slot3D []slot3D;
    public void WinChecker(Slot3D[] slot3D)
    {
        for (int i = 0; i < 9; i++)// HorizontalWinLines
        {
            Slot3D WP1 = TPaL.gridSlots[0 + (i * 3)].GetComponent<Slot3D>();// WP1 means win  position 1
            Slot3D WP2 = TPaL.gridSlots[1 + (i * 3)].GetComponent<Slot3D>();// WP2 means win  position 2
            Slot3D WP3 = TPaL.gridSlots[2 + (i * 3)].GetComponent<Slot3D>();// WP3 means win  position 3
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalWinLines[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalWinLines[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
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
            Slot3D WP1 = TPaL.gridSlots[0 + i + p].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[3 + i + p].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[6 + i + p].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalWinLinesDiagonal[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalWinLinesDiagonal[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 9; i++)// VerticalWinLines
        {
            Slot3D WP1 = TPaL.gridSlots[0 + i].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[9 + i].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[18 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalWinLines[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalWinLines[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesF
        {
            Slot3D WP1 = TPaL.gridSlots[0 + i].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[12 + i].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[24 + i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesF[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesR
        {
            Slot3D WP1 = TPaL.gridSlots[6 - (i * 3)].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[16 - (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[26 - (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesR[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesB
        {
            Slot3D WP1 = TPaL.gridSlots[8 - i].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[14 - i].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[20 - i].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesB[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = TPaL.gridSlots[2 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[10 + (i * 3)].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[18 + (i * 3)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                VerticalDiagonalWinLinesL[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
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
            Slot3D WP1 = TPaL.gridSlots[0 + (i * 6 - p)].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[13].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[26 - (i * 6 - p)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                DiagonalMultiPlane[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                DiagonalMultiPlane[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = TPaL.gridSlots[0 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[4 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[8 + (i * 9)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalDiagonalWinLinesFR[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalDiagonalWinLinesFR[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
        for (int i = 0; i < 3; i++)// VerticalDiagonalWinLinesL
        {
            Slot3D WP1 = TPaL.gridSlots[2 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP2 = TPaL.gridSlots[4 + (i * 9)].GetComponent<Slot3D>();
            Slot3D WP3 = TPaL.gridSlots[6 + (i * 9)].GetComponent<Slot3D>();
            if (WP1.GetSymbolType() == Symbol.Type.X && WP2.GetSymbolType() == Symbol.Type.X && WP3.GetSymbolType() == Symbol.Type.X)
            {
                HorizontalDiagonalWinLinesFL[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
            if (WP1.GetSymbolType() == Symbol.Type.O && WP2.GetSymbolType() == Symbol.Type.O && WP3.GetSymbolType() == Symbol.Type.O)
            {
                HorizontalDiagonalWinLinesFL[i].SetActive(true);
                UITD.WinDisplayUI();
                winState = true;
                return;
            }
        }
    }
    public void NextGameSetup()//find a way // remember to set every slot to empty 
    {
        winState = false;
        TPaL.currentSimbolTurn = 1;
        TPaL.turnCounter = 0;
        for (int i = 0; i < TPaL.gridSlots.Length; i++)
        {
            foreach (Transform child in TPaL.gridSlots[i].transform)
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
            TPaL.currentSimbolTurn = 1;
            UITD.turnIndicatorSprite[0].SetActive(false);
            UITD.turnIndicatorSprite[1].SetActive(true);
            firstTurnSimbol = true;
        }
        else
        {
            TPaL.currentSimbolTurn = 0;
            UITD.turnIndicatorSprite[0].SetActive(true);
            UITD.turnIndicatorSprite[1].SetActive(false);
            firstTurnSimbol = false;
        }
        UITD.OnFloreChainge(slot3D);
    }
}
