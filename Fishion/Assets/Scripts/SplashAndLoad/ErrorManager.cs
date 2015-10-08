/*============================================================================== 
 * Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;

public class ErrorManager : MonoBehaviour
{
    #region PUBLIC_METHODS
    public void OnErrorDialogDismiss()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Exit app
        Application.Quit();
#endif
    }
    #endregion // PUBLIC_METHODS
}