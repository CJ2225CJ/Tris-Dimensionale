using UnityEngine;

public class TrisPositioningAndLogic : MonoBehaviour
{
    public int currentSimbolTurn = 0; // 0 = X 1 = O
    public int turnCounter;
    public int currentFlore = 0;
    [SerializeField] private GameObject xSimbolPrefab;
    [SerializeField] private GameObject oSimbolPrefab;
    public GameObject[] gridSlots; // slots chaing name to make more clear
    public GameObject currentSymbol;
    public Symbol empty;
    public Symbol X3D;
    public Symbol O3D;
    public Slot3D[] slot3D;

    [SerializeField] private MonoInputSctipt monoInput;
    [SerializeField] private WinCheckerScript winChecker;
    [SerializeField] private UITD UITD;

    void Start()
    {
        GameSetup();
    }
    private void GameSetup()// chec if necesary
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        for (int i = 0; i < gridSlots.Length; i++)
        {
            Slot3D slot = gridSlots[i].GetComponent<Slot3D>();
            empty.GetComponent<Symbol>();
        }
    }
    public void Positioning(Slot3D[] slot3D)
    {
        if (winChecker.winState == false)
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
                    Slot3D slot = gridSlots[s + f].GetComponent<Slot3D>();
                    if (slot.GetSymbolType() == Symbol.Type.empty)
                    {
                        Transform p = gridSlots[s + f].transform;
                        if (currentSimbolTurn == 0)
                        {
                            slot3D[s + f].InstantiateSymbol(X3D);
                            Slot3D.Instantiate(currentSymbol, gridSlots[s + f].transform);
                            currentSimbolTurn = 1;
                        }
                        else
                        {
                            slot3D[s + f].InstantiateSymbol(O3D);
                            Slot3D.Instantiate(currentSymbol, gridSlots[s + f].transform);
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
                winChecker.WinChecker(slot3D);
            }
        }
    }
}
