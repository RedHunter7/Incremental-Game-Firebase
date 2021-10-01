using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
	[SerializeField] private Button _localButton;
    [SerializeField] private Button _cloudButton;

    // Start is called before the first frame update
    private void Start()
    {
        _localButton.onClick.AddListener (() =>
        {
            SetButtonInteractable (false);
            UserDataManager.LoadFromLocal ();
            SceneManager.LoadScene (1);
        });

        _cloudButton.onClick.AddListener (() =>
        {
            SetButtonInteractable (false);
            StartCoroutine (UserDataManager.LoadFromCloud (() => SceneManager.LoadScene (1)));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SetButtonInteractable (bool interactable)
    {
        _localButton.interactable = interactable;
        _cloudButton.interactable = interactable;
    }
}
