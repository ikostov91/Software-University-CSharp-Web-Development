using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


class DateModifier
{
    private string firstDate;
    private string secondDate;

    public string FirstDate
    {
        get { return this.firstDate;  }
        set { this.firstDate = value; }
    }

    public string SecondDate
    {
        get { return this.secondDate; }
        set { this.secondDate = value; }
    }

    public int CalculateDaysBetweenDates(string firstDate, string secondDate)
    {
        DateTime dateOne = DateTime.ParseExact(firstDate, "YYYY MM DD", CultureInfo.InvariantCulture);
        DateTime dateTwo = DateTime.ParseExact(secondDate, "YYYY MM DD", CultureInfo.InvariantCulture);

        return (int)(dateTwo - dateOne).TotalDays;
    }
}

