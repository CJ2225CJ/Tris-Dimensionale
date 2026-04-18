using UnityEngine;

public class TrisPositioningAndLogic : MonoBehaviour
{
    
    [SerializeField] public GameObject[] selectedSimbol;
    public GameObject[] F1trisSpaces; // obsolete
    public GameObject[] F2trisSpaces;
    public GameObject[] F3trisSpaces; 

    [SerializeField] private int currentFlore = 1;
    public int currentCellSimbol = 2; // 0 = X 1 = O 2 = empty
    public int currentSimbolTurn = 0; // 0 = x 1 = o
    [SerializeField] private GameObject xSimbol;
    [SerializeField] private GameObject oSimbol;
    public GameObject[] trisSpaces;
    public int turnCounter;
    public GameObject[] turnIndicatorSprite;
    public int[] spacesIdentifier;
    public GameObject[] simbols;

    void Start()
    {
        GameSetup();
    }

    private void GameSetup()
    {
        currentSimbolTurn = 0;
        turnCounter = 0;
        for (int i = 0; i < spacesIdentifier.Length; i++)
        {
            spacesIdentifier[i] = -100;
        }
    }

    public void TrisButtons(int number)
    {
        trisSpaces[number].GetComponent(Cels) SetActive(true);
    }

    // Old stuff

    // Update is called once per frame
    void Update()
    {
        if (currentFlore == 1)
        {
            
        }
        if (currentFlore == 2)
        {

        }
        if (currentFlore == 3)
        {

        }
        Positioning();
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
    public void TrisCellNumber(int cellNunber)
    {
        F1trisSpaces[cellNunber].gameObject.name = gameObject.name ; // find fix for this
        //F1trisSpaces[cellNunber].                                    // find a way to make the selected space non interactable after geting chosen

        if (currentSimbolTurn == 0)
        {
            currentSimbolTurn = 1;
        }
        else
        {
            currentSimbolTurn = 0;
        }
    }
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
    private void update()
    {
        //GameObject simbol 
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    Debug.Log("keypad1");
        //    Instantiate(selectedSimbol);
        //}
    }
    private void Positioning()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    Debug.Log("keypad1");
        //    selectedSimbolPso.transform.position = transform(-1, 0, -1);

        //    Instantiate(selectedSimbol);
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    selectedSimbol
        //    transform.SetPositionAndRotation(F1P1.transform.position, F1P1.transform.rotation);
        //    Instantiate(selectedSimbol);
        //}

    }
}
