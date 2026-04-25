using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrisPositioningAndLogic : MonoBehaviour
{
    
    [SerializeField] public GameObject[] selectedSimbol;
    public GameObject[] F1trisSpaces; // obsolete
    public GameObject[] F2trisSpaces;
    public GameObject[] F3trisSpaces; 

    //public int currentCellSimbol = 2; // 0 = X 1 = O 2 = empty
    public int currentSimbolTurn = 0; // 0 = x 1 = o
    [SerializeField] private GameObject xSimbolPrefab;
    [SerializeField] private GameObject oSimbolPrefab;
    public Vector3[] trisSpaces;
    public int turnCounter;
    public GameObject[] turnIndicatorSprite;
    public int[] spacesIdentifier;
    
    public Symbol.Type simbolType;
    public GameObject[] slots;
    //public SymbolDocumentInfo currentSimbol;
    public GameObject currentSymbol;
    public int currentFlore = 0;
    public TextMeshProUGUI FlorText;
    public Button[] trisButton;
    public Sprite[] simbolsSprite; // 0 = X 1 = O
    public Symbol.Type[] types;
    public Symbol[] symols;
    public Symbol empty;
    public Symbol X;
    public Symbol O;
    public Slot3D[] slot3D;

    void Start()
    {
        GameSetup();
    }
    void OnInput()
    {
        if (Input.anyKey)
        {
            Positioning(slot3D);
        }
    }
    
    void Positioning(Slot3D[] slot3D)//int number) //OPTIMIZE!!! // MAKE IT MORE READEBLE
    {
        //trisButton[number].image.sprite = simbolsSprite[currentSimbolTurn];
        int i = currentFlore * 9;
        if(currentSimbolTurn == 0)
        {
            currentSymbol = xSimbolPrefab;
        }
        else
        {
            currentSymbol = oSimbolPrefab;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) // make the UI wark // remember keypad + "i" optimazation
        {
            Slot3D slot = slots[0 + i].GetComponent<Slot3D>();
            if(slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[0 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[0 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[0 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[0 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[0 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Slot3D slot = slots[1 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[1 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[1 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[1 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[1 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[1 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Slot3D slot = slots[2 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[2 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[2 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[2 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[2 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[2 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Slot3D slot = slots[3 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[3 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[3 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[3 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[3 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[3 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Slot3D slot = slots[4 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[4 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[4 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[4 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[4 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[4 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Slot3D slot = slots[5 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[5 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[5 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[5 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[5 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[5 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Slot3D slot = slots[6 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[6 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[6 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[6 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[6 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[6 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Slot3D slot = slots[7 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[7 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[7 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[7 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[7 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[7 + i].transform);
                    currentSimbolTurn = 0;
                }
                turnCounter++;
            }
            else
            {
                Debug.Log("slot occupato");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Slot3D slot = slots[8 + i].GetComponent<Slot3D>();
            if (slot.GetSymbolType() == Symbol.Type.empty)
            {
                Transform p = slots[8 + i].transform;
                if (currentSimbolTurn == 0)
                {
                    slot3D[8 + i].InstantiateSymbol(X);
                    Slot3D.Instantiate(currentSymbol, slots[8 + i].transform);
                    currentSimbolTurn = 1;
                }
                else
                {
                    slot3D[8 + i].InstantiateSymbol(O);
                    Slot3D.Instantiate(currentSymbol, slots[8 + i].transform);
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
    //UI
    public void FlorUp()
    {
        if (currentFlore < 2)
        {
            currentFlore++;
        }
        FlorText.text = currentFlore.ToString();
    }

    public void FlorDown()
    {
        if(currentFlore > 0)
        {
            currentFlore--;
        }
        FlorText.text = currentFlore.ToString();
    }



    void OnbutonPres()
    {

    }
    // unuffical
    private void GameSetup()//find a way // remember to set every slot to empty
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        if (Input.GetButton("Jump"))
        {
            
        }

        for (int i = 0; i < slots.Length; i++)
        {
            Slot3D slot = slots[i].GetComponent<Slot3D>();
            empty.GetComponent<Symbol>();
        }
    }

    public void TrisButtons(int number)
    {
        //trisSpaces[number].GetComponent<GameObject>().gameObject; //find a way to make this wark
        Input.GetButtonDown("1");
    }
    // obsolete

    // Update is called once per frame
    void Update()
    {
        OnInput();
        //Positioning(slot3D);// not very efficent XD

        //if (Input.GetKeyDown("1"))
        //{
        //    Debug.Log("F1-P1");
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    Debug.Log("keypad1");
        //    Instantiate(selectedSimbol);
        //    F1P1.transform.position = selectedSimbol.transform.position;
        //}
    }
    //public void TrisCellNumber(int cellNunber)
    //{
    //    F1trisSpaces[cellNunber].gameObject.name = gameObject.name ; // find fix for this
    //    //F1trisSpaces[cellNunber].                                    // find a way to make the selected space non interactable after geting chosen

    //    if (currentSimbolTurn == 0)
    //    {
    //        currentSimbolTurn = 1;
    //    }
    //    else
    //    {
    //        currentSimbolTurn = 0;
    //    }
    //}
    private void TryToSelectPositionF1()
    {
        // p1 logic
        //if (Input.GetKeyDown("1") && F1P1 == empty)
        //{
        //    selectedSimbol // spawn() in F1P1.transform;
        //}
        //if (Input.GetKeyDown("1") && F1P1 == full)
        //{
        //    Debug.Log("questa posizione e gia piena");
        //}
    }
    //private void Positioning()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Keypad1))
    //    //{
    //    //    Debug.Log("keypad1");
    //    //    selectedSimbolPso.transform.position = transform(-1, 0, -1);

    //    //    Instantiate(selectedSimbol);
    //    //}
    //    //if (Input.GetKeyDown(KeyCode.Keypad1))
    //    //{
    //    //    selectedSimbol
    //    //    transform.SetPositionAndRotation(F1P1.transform.position, F1P1.transform.rotation);
    //    //    Instantiate(selectedSimbol);
    //    //}

    //    if (Input.GetKeyDown(KeyCode.Keypad1))
    //    {
    //        Debug.Log("keypad1");
    //        Slot3D.Instantiate(xSimbolPrefab, slots[0].transform);
    //        //slots[0] =
    //        //currentSimbol = xSimbolPrefab;
    //    }
    //}
}
