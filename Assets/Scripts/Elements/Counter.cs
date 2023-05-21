using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField]
    List<Sprite> numbers;
    [SerializeField]
    List<Image> character;

    public void SetNumber(int num)
    {
        var res = num % 10;
        character[0].sprite = numbers[res];

        if(num >= 10)
        {
            character[1].gameObject.SetActive(true);
            res = num % 100;
            int cnt = 0;
            int comparator;

            do
            {
                cnt++;
                comparator = 10 * cnt;
            }
            while (res >= comparator);

            character[1].sprite = numbers[cnt - 1];
        }
        else
        {
            character[1].gameObject.SetActive(false);
        }

        if (num >= 100)
        {
            character[2].gameObject.SetActive(true);
            res = num % 1000;
            int cnt = 0;
            int comparator;

            do
            {
                cnt++;
                comparator = 100 * cnt;
            }
            while (res >= comparator);

            character[2].sprite = numbers[cnt - 1];
        }
        else
        {
            character[2].gameObject.SetActive(false);
        }
    }
}