using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DateClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var today = DateTime.Today;
        var dayOfWeek = today.DayOfWeek;
        // ここから数字

        var japa = new JapaneseCalendar();
        var isLerpYear = DateTime.IsLeapYear(2016);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
