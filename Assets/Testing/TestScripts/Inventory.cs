using UnityEngine;
using TMPro;

//on the inventory manager
public class Inventory : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject CardInventoryUI;
    public GameObject ItemInventoryUI;
    public GameObject GameplayUI;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject CameraRotateRoom;
    public GameObject Player;
    public GameObject BacktoPlaying;

    public TextMeshProUGUI Card;

    [Header("Card Page Info")]
    public GameObject[] CardPage;
    public int CardCurrentPage = 0;
    public bool cardinventoryopen = false;

    [Header("Item Page Info")]
    public GameObject[] ItemPage;
    public int ItemCurrentPage = 0;
    public bool iteminventoryopen = false;

    [Header("Timer Info")]
    public float timer;
    public bool timeractive;

    private void FixedUpdate()
    {
        if(timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        
        if(timer > 0.5f)
        {
            timeractive = false;
            timer = 0;
        }

        if(Input.GetKey(KeyCode.C))
        {
            if(cardinventoryopen && timeractive == false)
            {
                CardInventoryUI.SetActive(false);
                cardinventoryopen = false;
                timeractive = true;
            }

            if(cardinventoryopen == false && timeractive == false)
            {
                ItemInventoryUI.SetActive(false);
                iteminventoryopen = false;
                CardInventoryUI.SetActive(true);
                cardinventoryopen = true;
                timeractive = true;
            }
        }

        if (Input.GetKey(KeyCode.I))
        {
            if (iteminventoryopen && timeractive == false)
            {
                ItemInventoryUI.SetActive(false);
                iteminventoryopen = false;
                timeractive = true;
            }

            if (iteminventoryopen == false && timeractive == false)
            {
                CardInventoryUI.SetActive(false);
                cardinventoryopen = false;
                ItemInventoryUI.SetActive(true);
                iteminventoryopen = true;
                timeractive = true;
            }
        }
    }


    public void Card1Clicked()
    {
        Object1.SetActive(true);
        CameraRotateRoom.SetActive(true);
        Player.SetActive(false);
        BacktoPlaying.SetActive(true);
        GameplayUI.SetActive(false);
        cardinventoryopen = false;
        Card.text = "The Cube Card";
    }

    public void Card2Clicked()
    {
        Object2.SetActive(true);
        CameraRotateRoom.SetActive(true);
        Player.SetActive(false);
        BacktoPlaying.SetActive(true);
        GameplayUI.SetActive(false);
        Card.text = "The Fish Card";

    }

    public void BacktoGame()
    {
        Player.SetActive(true);
        CameraRotateRoom.SetActive(false);
        Object1.SetActive(false);
        GameplayUI.SetActive(true);
        Object2.SetActive(false);
        BacktoPlaying.SetActive(false);
    }

    public void CardNextPage()
    {
        CardPage[CardCurrentPage].SetActive(false);
        CardCurrentPage++;
        CardPage[CardCurrentPage].SetActive(true);
    }

    public void CardPreviousPage()
    {
        CardPage[CardCurrentPage].SetActive(false);
        CardCurrentPage--;
        CardPage[CardCurrentPage].SetActive(true);
    }

    public void ItemNextPage()
    {
        ItemPage[ItemCurrentPage].SetActive(false);
        ItemCurrentPage++;
        ItemPage[ItemCurrentPage].SetActive(true);
    }

    public void ItemPreviousPage()
    {
        ItemPage[ItemCurrentPage].SetActive(false);
        ItemCurrentPage--;
        ItemPage[ItemCurrentPage].SetActive(true);
    }
}
