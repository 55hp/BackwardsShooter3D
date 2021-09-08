using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    //private static T instance;

    #endregion

    #region Properties

    public static T Instance { get; private set; }

    #endregion

    #region Methods
    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
