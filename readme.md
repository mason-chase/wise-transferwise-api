![transferwise-logo](transferwise-logo.png)

# Wise.com (Formerly known as TransferWise.com) API in C# 

Currently working on Mocked data (collected based on samples within .json folder)

Usage (Get list of banks in US):
```C#
bool sanboxBool = true;
WiseClient wiseClient = new("WISE_API_KEY", sanboxBool);
BankListRequest request = new(CountryIso2Code.UnitedStates);
BankListResponse response = wiseClient.GetBankList(request);
```


