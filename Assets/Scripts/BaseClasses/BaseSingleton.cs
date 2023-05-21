using UnityEngine;

/// <summary>
/// Abstract class to implement the Singleton pattern
/// It is mandatory to ensure the presence of the defined class in the scene 
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseSingleton<T> : MonoBehaviour, ISingleton<T> where T : MonoBehaviour
{
	private static T _instance = null;

	public void SetInstance(T item)
	{
		_instance = item;
	}

	public static T GetInstance()
	{
		if (_instance == null)
			Debug.Log("Missing Instance");

		return _instance;
	}

	T ISingleton<T>.GetInstance()
	{
		return GetInstance();
	}

    void OnDisable()
	{
		// release reference on exit
		_instance = null;
	}
}