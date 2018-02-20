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
        DateTime dateOne = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime dateTwo = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((int)(dateTwo - dateOne).TotalDays);
    }
}

