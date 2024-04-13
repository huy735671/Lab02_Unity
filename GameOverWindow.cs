using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
   public Text winerName;
   public Button restartButton;

    private void Awake() 
    {
        restartButton.onClick.AddListener(Onclick);

    }
   

   public void SetName(string s)
   {
    winerName.text =s;
   }
   public void Onclick()
   {
    SceneManager.LoadScene("SampleScene");
   
   }
}
