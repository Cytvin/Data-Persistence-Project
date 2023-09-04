using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _userNameTextField;

    private void Start()
    {
        _bestScoreText.SetText($"Best Score: {UserdataManager.Instance.HighScoreUsername} : {UserdataManager.Instance.Score}");
        _userNameTextField.text = UserdataManager.Instance.HighScoreUsername;
    }

    public void StartGame()
    {
        UserdataManager.Instance.CurrentUsername = _userNameTextField.text;

        UserdataManager.Instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
