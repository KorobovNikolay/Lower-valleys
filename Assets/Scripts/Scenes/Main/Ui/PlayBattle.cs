using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBattle : MonoBehaviour
{
    [SerializeField] Button _playBattleButton = null;

    private void Start()
    {
        _playBattleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Battle");
        });
    }
}
