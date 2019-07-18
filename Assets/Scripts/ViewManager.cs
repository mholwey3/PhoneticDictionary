using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class ViewManager
{
    public static Hashtable Arguments { get; private set; }

    public const string VIEW_SEARCH = "Views/Search";
    public const string VIEW_ITEM_DISPLAY = "Views/ItemDetail";

    public static void LoadView(string sSceneToLoad)
    {
        SceneManager.LoadScene(sSceneToLoad);
    }

    public static void LoadView(string sSceneToLoad, Hashtable args)
    {
        Arguments = args;
        SceneManager.LoadScene(sSceneToLoad);
    }
	
}
