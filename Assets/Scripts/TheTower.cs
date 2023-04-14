using UnityEngine;
using UnityEngine.SceneManagement;

//used on the tower gameobject

public class TheTower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("WinScreen"); //as the player has reached the tower, load the WinScreen
    }

}
