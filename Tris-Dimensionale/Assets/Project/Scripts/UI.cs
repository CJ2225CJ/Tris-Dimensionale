using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image x;
    public Image o;
    public Image blank;
    public int xScore;
    public int oScore;
    public GameObject[] turnIndicatorSprite;
    public Button[] uiTrisSpaces;
    public int currentSimbolTurn = 0;
    public Sprite[] simbolsSprite;
    public TextMeshProUGUI xScoreText;
    public TextMeshProUGUI oScoreText;
    void Start()
    {
        for (int i = 0; i < uiTrisSpaces.Length; i++)
        {
            uiTrisSpaces[i].interactable = true;
            uiTrisSpaces[i].GetComponent<Image>().sprite = x.sprite;
        }
    }
    public void TrisButtons(int nunber)
    {
        uiTrisSpaces[nunber].image.sprite = simbolsSprite[currentSimbolTurn];
        uiTrisSpaces[nunber].interactable = false;

        if (currentSimbolTurn == 0)
        {
            for (int i = 0; i < uiTrisSpaces.Length; i++)
            {
                if (uiTrisSpaces[i].interactable == true)
                {
                    uiTrisSpaces[i].GetComponent<Image>().sprite = o.sprite;
                }
            }
            currentSimbolTurn = 1;
            turnIndicatorSprite[0].SetActive(false);
            turnIndicatorSprite[1].SetActive(true);
        }
        else
        {
            for (int i = 0; i < uiTrisSpaces.Length; i++)
            {
                if (uiTrisSpaces[i].interactable == true)
                {
                    uiTrisSpaces[i].GetComponent<Image>().sprite = x.sprite;
                }
            }
            currentSimbolTurn = 0;
            turnIndicatorSprite[0].SetActive(true);
            turnIndicatorSprite[1].SetActive(false);
        }
    }
}
