# MoneyMeChallenge

## Overview
Technical Challenge for MoneyMe .NET Developer Position

---

## Tools Used
1. Visual Studio 2022 Version 17.11.5
2. Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64) Express Edition (64-bit)
3. UI - Blazor, MudBlazor Component Library
4. Backend - C#, EF Core (dotnet 8), Code First Migrations

---

## Steps to Restore the Database
Follow these steps to restore the database:
1. Open command prompt and go to path `..\MoneyMeChallenge\MoneyMe_Loan_API\MoneyMe_Loan_API`
2. Run `dotnet ef database update`

---

## Projects to Run
List the projects that need to be run:
1. **Backend Service**: Located in `..\MoneyMeChallenge\MoneyMe_Loan_API\MoneyMe_Loan_API`.
   - Run `dotnet run` in the backend directory.
2. **Frontend**: Located in `..\MoneyMeChallenge\MoneyMe_Loan_API\MoneyMe_Loan_FrontEnd`.
   - Run `dotnet run` and `npm start` in the frontend directory.


## API Endpoints for third party apps

**POST** `https://localhost:7239/api/money-me-loan-application/redirect`

### Request Body:

```
    {
        "AmountRequired":"5000",
        "Term":"2",
        "Title":"Mr.",
        "FirstName":"John",
        "LastName": "doe",
        "DateOfBirth":"1900-01-01",
        "Mobile":"0422111333",
        "Email":"layton@flower.com.au"
    }

```