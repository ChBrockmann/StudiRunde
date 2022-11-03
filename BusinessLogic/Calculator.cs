namespace BusinessLogic;

public class Calculator
{
    public int CalculateUrlaubsanspruchForGivenYear(int year, DateTime? firstWorkDayOfUser)
    {
        if (firstWorkDayOfUser is null)
        {
            return 0;
        }
        
        int defaultYearlyHolidayInDays = GetNormalYearlyHoliday(year);
        
        if (firstWorkDayOfUser.Value.Year == year)
        {
            int workingMonths = 13 - firstWorkDayOfUser.Value.Month;
            decimal urlaubProMonth = Decimal.Divide(defaultYearlyHolidayInDays, 12);
            return (int)Math.Round(workingMonths * urlaubProMonth);
        }
        else
        {
            return defaultYearlyHolidayInDays;
        }
        
    }
    
    private int GetNormalYearlyHoliday(int year)
    {
        int result = 20;

        if(year >= 2022)
        {
            result = 22;
        }

        return result;
    }
}