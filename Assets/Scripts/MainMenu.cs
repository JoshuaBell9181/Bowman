using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayHumanVsComputer(){
       SceneManager.LoadScene(1);
   }

   public void PlayHumanVsHuman(){
       SceneManager.LoadScene(2);
   }

   public void back(){
       SceneManager.LoadScene(0);
   }
}
