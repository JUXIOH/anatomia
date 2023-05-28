using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsersManager : MonoBehaviour
{
    public static UsersManager instance;

    [SerializeField] Button user1;
    [SerializeField] Button user2;
    [SerializeField] Button user3;
    [SerializeField] TMPro.TMP_Text user1Txt;
    [SerializeField] TMPro.TMP_Text user2Txt;
    [SerializeField] TMPro.TMP_Text user3Txt;

    public const string USERINAME_KEY = "userIName";
    public const string USERIINAME_KEY = "userIIName";
    public const string USERIIINAME_KEY = "userIIIName";

    public const string USERIACTIVE_KEY = "userIActive";
    public const string USERIIACTIVE_KEY = "userIIActive";
    public const string USERIIIACTIVE_KEY = "userIIIActive";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadUsers();
    }

    private void Update()
    {
        LoadUsers();
    }

    void LoadUsers()
    {
        int userIActive = PlayerPrefs.GetInt(USERIACTIVE_KEY, 0);
        int userIIActive = PlayerPrefs.GetInt(USERIIACTIVE_KEY, 0);
        int userIIIActive = PlayerPrefs.GetInt(USERIIIACTIVE_KEY, 0);

        if (userIActive == 1)
        {
            user1.interactable = false;
        }

        if (userIIActive == 1)
        {
            user2.interactable = false;
        }

        if (userIIIActive == 1)
        {
            user3.interactable = false;
        }

        string userIName = PlayerPrefs.GetString(USERINAME_KEY, "NA");
        string userIIName = PlayerPrefs.GetString(USERIINAME_KEY, "NA");
        string userIIIName = PlayerPrefs.GetString(USERIIINAME_KEY, "NA");

        user1Txt.SetText(userIName);
        user2Txt.SetText(userIIName);
        user3Txt.SetText(userIIIName);
    }
}
