using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuSwitch : MonoBehaviour
{
    [SerializeField] private GameObject levelSet;
    [SerializeField] private GameObject optionsSet;
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject shoppingSet;

    [SerializeField] private Image icon01;
    [SerializeField] private Image icon02;
    [SerializeField] private Image icon03;
    [SerializeField] private Image icon04;

    [SerializeField, HideInInspector] private bool Dia01 = true;
    [SerializeField, HideInInspector] private bool Dia02 = false;
    [SerializeField, HideInInspector] private bool Dia03 = false;
    [SerializeField, HideInInspector] private bool Dia04 = false;





    public void Start()
    {
        LockedBTN();
        
    }
    public void Update()
    {
        LockedBTN();

    }

    public void LevelSet()
    {
        levelSet.SetActive(true);
    }

    public void OptionsSet() 
    { 
        optionsSet.SetActive(true);
    }

    public void Creditos()
    {
        creditos.SetActive(true);
    }

    public void ShoppingSet() 
    { 
        shoppingSet.SetActive(true);
    }
    public void iniciar(string level) 
    {
        SceneManager.LoadScene(level);
    }

    public void LockedBTN()
    {
        if (!Dia01)
        {
            icon01.gameObject.SetActive(true);
        }
        else 
        { 
            icon01.gameObject.SetActive(false);
        }

    }

    public void Return()
    {
       
            levelSet.SetActive(false);
              
            optionsSet.SetActive(false);    
       
            creditos.SetActive(false);    
       
            shoppingSet.SetActive(false);
        

    }

   
}
