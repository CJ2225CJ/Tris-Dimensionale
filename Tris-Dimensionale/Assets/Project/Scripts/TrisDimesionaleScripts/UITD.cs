using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITD : MonoBehaviour
{
    public int xScore;
    public int oScore;
    public Button[] trisSpaces;
    public GameObject xWinSprite;
    public GameObject oWinSprite;
    public GameObject[] turnIndicatorSprite;
    [SerializeField] private GameObject xSimbolPrefab;
    [SerializeField] private GameObject oSimbolPrefab;
    [SerializeField] private GameObject[] selectedSimbol;
    [SerializeField] private Sprite[] simbolsSprite; // 0 = x 1 = o
    [SerializeField] private Image x2D;
    [SerializeField] private Image o2D;
    [SerializeField] private TextMeshProUGUI xScoreText;
    [SerializeField] private TextMeshProUGUI oScoreText;
    [SerializeField] private GameObject xDrawOSprite;
    [SerializeField] private Image blank;
    [SerializeField] private TextMeshProUGUI FlorText;
    private float nextRoundTime = 5f;
    private IEnumerator nextGameTimer;
    private bool firstTurnSimbol = false;
    private bool monoTrigget = false; // ???
    private int nunber;
    [SerializeField] private Slot3D[] slot3D;
    [SerializeField] private WinCheckerScript winChecker;
    [SerializeField] private TrisPositioningAndLogic TPaL;
    void Start()
    {
        UISetup();
    }

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
    public void UIButtons(int nunber) // dout this warks
    {
        //int tb = tbn;  // tb means UI tris buttons
        trisSpaces[nunber].image.sprite = simbolsSprite[TPaL.currentSimbolTurn];
        trisSpaces[nunber].interactable = false;

        int f = TPaL.currentFlore * 9; // f means flor
        if (TPaL.currentSimbolTurn == 0)
        {
            TPaL.currentSymbol = xSimbolPrefab;
        }
        else
        {
            TPaL.currentSymbol = oSimbolPrefab;
        }

        Slot3D slot = TPaL.gridSlots[nunber + f].GetComponent<Slot3D>();
        if (slot.GetSymbolType() == Symbol.Type.empty)
        {
            Transform p = TPaL.gridSlots[nunber + f].transform;
            if (TPaL.currentSimbolTurn == 0)
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
                TPaL.slot3D[nunber + f].InstantiateSymbol(TPaL.X3D);
                Slot3D.Instantiate(TPaL.currentSymbol, TPaL.gridSlots[nunber + f].transform);
                TPaL.currentSimbolTurn = 1;
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
                TPaL.slot3D[nunber + f].InstantiateSymbol(TPaL.O3D);
                Slot3D.Instantiate(TPaL.currentSymbol, TPaL.gridSlots[nunber + f].transform);
                TPaL.currentSimbolTurn = 0;
            }
            TPaL.turnCounter++;
        }
        else
        {
            Debug.Log("slot occupato");
        }
    }

    public void OnFloreChainge(Slot3D[] slot3D)
    {
        int f = TPaL.currentFlore * 9; // f means flor
        for (int i = 0; i < 9; i++)
        {
            Button button = trisSpaces[i];
            Image image = button.GetComponent<Image>();
            Slot3D slot = TPaL.gridSlots[i + f].GetComponent<Slot3D>();
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
            if (slot.GetSymbolType() == Symbol.Type.empty && TPaL.currentSimbolTurn == 0)
            {
                turnIndicatorSprite[0].SetActive(true);
                turnIndicatorSprite[1].SetActive(false);
                button.interactable = true;
                image.sprite = x2D.sprite;
            }
            if (slot.GetSymbolType() == Symbol.Type.empty && TPaL.currentSimbolTurn == 1)
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
        if (TPaL.currentFlore < 2)
        {
            TPaL.currentFlore++;
            FlorText.text = TPaL.currentFlore.ToString();
            OnFloreChainge(slot3D);
        }
    }

    public void FlorDown()
    {
        if (TPaL.currentFlore > 0)
        {
            TPaL.currentFlore--;
            FlorText.text = TPaL.currentFlore.ToString();
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
        winChecker.WinChecker(slot3D);
    }
    public void UIButton2()
    {
        UIButtons(nunber = 1);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton3()
    {
        UIButtons(nunber = 2);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton4()
    {
        UIButtons(nunber = 3);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton5()
    {
        UIButtons(nunber = 4);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton6()
    {
        UIButtons(nunber = 5);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton7()
    {
        UIButtons(nunber = 6);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton8()
    {
        UIButtons(nunber = 7);
        winChecker.WinChecker(slot3D);
    }
    public void UIButton9()
    {
        UIButtons(nunber = 8);
        winChecker.WinChecker(slot3D);
    }
    public void WinDisplayUI()
    {
        for (int i = 0; i < trisSpaces.Length; i++)
        {
            if (trisSpaces[i].interactable == true)
            {
                trisSpaces[i].GetComponent<Image>().sprite = blank.sprite;
            }
        }
        if (TPaL.currentSimbolTurn == 1)
        {
            xScore++;
            xScoreText.text = xScore.ToString();
            xWinSprite.gameObject.SetActive(true);
            xDrawOSprite.gameObject.SetActive(false);
        }
        else if (TPaL.currentSimbolTurn == 0)
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
        winChecker.NextGameSetup();
        oWinSprite.SetActive(false);
        xWinSprite.SetActive(false);
    }
}
