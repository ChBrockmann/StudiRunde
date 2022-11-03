using System;
using System.Collections.Generic;
using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace BusinessLogicTests;

public class CalculatorTests
{
    private readonly Calculator _sut = new();
    public static IEnumerable<object[]> GetTestData_FirstDayOfWorkIsLastYear()
    {
        yield return new object[] { 2020, new DateTime(2019, 05, 01), 20 };
        yield return new object[] { 2021, new DateTime(2020, 05, 01), 20 };
        yield return new object[] { 2022, new DateTime(2021, 05, 01), 22 };
    }
    public static IEnumerable<object[]> GetTestData_FirstDayOfWorkIsInSameYear()
    {
        yield return new object[] { 2021, new DateTime(2021, 01, 01), 20 };
        yield return new object[] { 2021, new DateTime(2021, 02, 01), 18 };
        yield return new object[] { 2021, new DateTime(2021, 03, 01), 17 };
        yield return new object[] { 2021, new DateTime(2021, 04, 01), 15 };
        yield return new object[] { 2021, new DateTime(2021, 05, 01), 13 };
        yield return new object[] { 2021, new DateTime(2021, 06, 01), 12 };
        yield return new object[] { 2021, new DateTime(2021, 07, 01), 10 };
        yield return new object[] { 2021, new DateTime(2021, 08, 01), 8 };
        yield return new object[] { 2021, new DateTime(2021, 09, 01), 7 };
        yield return new object[] { 2021, new DateTime(2021, 10, 01), 5 };
        yield return new object[] { 2021, new DateTime(2021, 11, 01), 3 };
        yield return new object[] { 2021, new DateTime(2021, 12, 01), 2 };
        
        yield return new object[] { 2022, new DateTime(2022, 01, 01), 22 };
        yield return new object[] { 2022, new DateTime(2022, 02, 01), 20 };
        yield return new object[] { 2022, new DateTime(2022, 03, 01), 18 };
        yield return new object[] { 2022, new DateTime(2022, 04, 01), 17 };
        yield return new object[] { 2022, new DateTime(2022, 05, 01), 15 };
        yield return new object[] { 2022, new DateTime(2022, 06, 01), 13 };
        yield return new object[] { 2022, new DateTime(2022, 07, 01), 11 };
        yield return new object[] { 2022, new DateTime(2022, 08, 01), 9 };
        yield return new object[] { 2022, new DateTime(2022, 09, 01), 7 };
        yield return new object[] { 2022, new DateTime(2022, 10, 01), 6 };
        yield return new object[] { 2022, new DateTime(2022, 11, 01), 4 };
        yield return new object[] { 2022, new DateTime(2022, 12, 01), 2 };
    }


    [Theory]
    [MemberData(nameof(GetTestData_FirstDayOfWorkIsLastYear))]
    public void UrlaubsanspruchForGivenYear_FirstDayOfWorkIsLastYear(int inputYear, DateTime inputFirstDayOfUser ,int expected)
    {
        int actual = _sut.CalculateUrlaubsanspruchForGivenYear(inputYear, inputFirstDayOfUser);

        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetTestData_FirstDayOfWorkIsInSameYear))]
    public void UrlaubsanspruchForGivenYear_FirstDayOfWorkIsInSameYear(int inputYear, DateTime inputFirstDayOfUser ,int expected)
    {
        int actual = _sut.CalculateUrlaubsanspruchForGivenYear(inputYear, inputFirstDayOfUser);

        actual.Should().Be(expected);
    }
}