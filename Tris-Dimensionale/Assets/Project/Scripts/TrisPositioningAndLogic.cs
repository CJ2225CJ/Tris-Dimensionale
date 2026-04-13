using System;
using Unity.VisualScripting;
using UnityEngine;

public class TrisPositioningAndLogic : MonoBehaviour
{
    private GameObject F1P1;
    private GameObject F1P2;
    private GameObject F1P3;
    private GameObject F1P4;
    private GameObject F1P5;
    private GameObject F1P6;
    private GameObject F1P7;
    private GameObject F1P8;
    private GameObject F1P9;

    private GameObject F2P1;
    private GameObject F2P2;
    private GameObject F2P3;
    private GameObject F2P4;
    private GameObject F2P5;
    private GameObject F2P6;
    private GameObject F2P7;
    private GameObject F2P8;
    private GameObject F2P9;

    private GameObject F3P1;
    private GameObject F3P2;
    private GameObject F3P3;
    private GameObject F3P4;
    private GameObject F3P5;
    private GameObject F3P6;
    private GameObject F3P7;
    private GameObject F3P8;
    private GameObject F3P9;
    //public Transform F1P1;

    [SerializeField] private int currentFlore = 1;
    [SerializeField] public GameObject[] selectedSimbol;
    [SerializeField] private GameObject xSimbol;
    [SerializeField] private GameObject oSimbol;
    public int cellCurrentSimbolStat = 2; // 0 = X 1 = O 2 = empty
    public GameObject[] F1trisSpaces; // try diferent forms to make this wark
    public GameObject[] F2trisSpaces;
    public GameObject[] F3trisSpaces; 
    public int currentSimbolTurn = 0; // 0 = x 1 = o

    private void GameSetup()
    {
        currentSimbolTurn = 0;
        //for (int i = 0; i < F1trisSpaces.Length; i++)
        //{
        //    F1trisSpaces[i].SetActive(true);
        //    F1trisSpaces[i].GetComponent<GameObject>().gameObject.name = null;

        //}
        //currentSimbolTurn = 0;
        //for (int i = 0; i < F1trisSpaces.Length; i++)
        //{
        //    F2trisSpaces[i].SetActive(true);
        //    F2trisSpaces[i].GetComponent<GameObject>().gameObject.name = null;

        //}
        //currentSimbolTurn = 0;
        //for (int i = 0; i < F1trisSpaces.Length; i++)
        //{
        //    F3trisSpaces[i].SetActive(true);
        //    F3trisSpaces[i].GetComponent<GameObject>().gameObject.name = null;

        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

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
