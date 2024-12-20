using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.Networking;

public class gs_web : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject notif, console;
    [SerializeField] private gs_loading levelLoadingScript;
    

    private void Start()
    {
        StartCoroutine(Login("user1", "password"));
    }

    public void loggy(string user, string pass)
    {
        StartCoroutine(Login(user, pass));
    }

    public void reggy(string user, string pass)
    {
        StartCoroutine(Register(user, pass));
    }

    public IEnumerator Login(string username, string password) {

        WWWForm form = new WWWForm();
        string url = "http://localhost/Aardvark/login.php";
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            //yield return www.Send();

            yield return www.SendWebRequest();

            
            switch (www.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    pingTerminal("UnityWebRequestErr:" + www.error);
                    break;
                case UnityWebRequest.Result.Success:
                    pingTerminal("Unity Web Request Recieved!");
                    pingTerminal(www.downloadHandler.text);
                    break;
            }
                        
        }
    }

    public IEnumerator Register(string username, string password)
    {

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/Aardvark/register.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                pingTerminal("An error has occured:");
                Debug.Log(www.error);
            }
            else
            {
                //Shows results as text
                pingTerminal("Connected to database!");
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    #region NOTIFS
    private void pingTerminal(string noteText)
    {
        Debug.Log(noteText);
        GameObject notes = Instantiate(notif, console.transform, false);
        notes.GetComponentInChildren<gs_Notification>().updateText(noteText);
    }
    #endregion
}
