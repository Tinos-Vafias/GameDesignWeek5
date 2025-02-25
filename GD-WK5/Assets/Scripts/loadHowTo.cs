using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class loadHowTo : MonoBehaviour
{
    public string sceneToLoad;
    public Button myButton; 
    
    public void LoadHowToScreen()
    {
        SceneManager.LoadScene(sceneToLoad); 
    }
}
