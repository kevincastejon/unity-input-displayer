using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void GoToWebsite()
    {
        Application.OpenURL("https://www.kevincastejon.fr/");
    }
}
