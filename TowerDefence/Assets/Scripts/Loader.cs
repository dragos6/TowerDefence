using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        KeyValuePair<int, string> course = new KeyValuePair<int, string>(1, "duduman");
        course.Print();

        KeyValuePair<string, string> lesson = new KeyValuePair<string, string>("number 1", "for four for four");
        lesson.Print();

    }
}

public class KeyValuePair<TKey, TValue>
{
    public TKey key;
    public TValue value;

    public KeyValuePair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
    public void Print()
    {
        Debug.Log("Key:" +key.ToString() +"\n"+ "Value:" + value.ToString());
    }
}
