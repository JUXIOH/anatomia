using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField user1nameTxtField;
    [SerializeField] TMPro.TMP_InputField user2nameTxtField;
    [SerializeField] TMPro.TMP_InputField user3nameTxtField;
    [SerializeField] TMPro.TMP_Text user1Text;
    [SerializeField] TMPro.TMP_Text user2Text;
    [SerializeField] TMPro.TMP_Text user3Text;

    public const string USER_USERIN = "userIName";
    public const string USER_USERIIN = "userIIName";
    public const string USER_USERIIIN = "userIIIName";

    public const string USER_USERIA = "userIActive";
    public const string USER_USERIIA = "userIIActive";
    public const string USER_USERIIIA = "userIIIActive";

    public void getUser1Name()
    {
        string username = user1nameTxtField.text.ToString();

        if (username.Equals(""))
        {
            user1Text.SetText("don't be coy... tell me your name.");
        }
        else
        {
            PlayerPrefs.SetString(UsersManager.USERINAME_KEY, username);
            PlayerPrefs.SetInt(UsersManager.USERIACTIVE_KEY, 1);
        }
    }

    public void getUser2Name()
    {
        string username = user2nameTxtField.text.ToString();

        if (username.Equals(""))
        {
            user2Text.SetText("don't be coy... tell me your name.");
        }
        else
        {
            PlayerPrefs.SetString(UsersManager.USERIINAME_KEY, username);
            PlayerPrefs.SetInt(UsersManager.USERIIACTIVE_KEY, 1);
        }
    }

    public void getUser3Name()
    {
        string username = user3nameTxtField.text.ToString();

        if (username.Equals(""))
        {
            user3Text.SetText("don't be coy... tell me your name.");
        }
        else
        {
            PlayerPrefs.SetString(UsersManager.USERIIINAME_KEY, username);
            PlayerPrefs.SetInt(UsersManager.USERIIIACTIVE_KEY, 1);
        }
    }
}
