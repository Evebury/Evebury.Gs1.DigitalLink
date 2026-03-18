# Evebury.Gs1.DigitalLink

A comprehensive .NET library for validating GDSN GS1 messages. This engine acts as a pre-validation layer, ensuring data quality and compliance before messages are delivered to the GS1 Network.

## 🚀 Features
- **Validated**: Digital links are validated. 
- **Strongly Typed**: This library will output the raw code and values from strongly typed objects.
- **Rectified**: Rectified GS1 segments leaving a far smaller subset of Segment types to choose from.
- **Operational Efficiency**: Elaborate validation errors, reducing manual troubleshooting time.

## 🎯 Quick Start

```csharp
using Evebury.Gs1.DigitalLink;
using System;
using System.Collections.Generic;

//construct the builder with a primary segment
DigitalLinkBuilder builder = new(Primary.GTIN("00074562000525"));

//optionally set your custom domain
builder.SetCustomDomainUri("https://www.evebury.com");

//add a date
builder.AddDate(DateType.PRODUCTION_DATE, DateTime.Now);

//add a list value
builder.AddString(StringType.INTERNAL_COMPANY, "value1/with slash");
builder.AddString(StringType.INTERNAL_COMPANY, "value2");

//add net weight value (decimal precision inferred from value)
builder.AddNetWeight(290.3, WeightUnit.POUNDS);

//add price and set value to the decimal precision
builder.AddPrice(PriceType.PRICE_TRADE_ITEM, 88, 2, CurrencyCode.EUR);

//uncomment to raise validation error
//builder.AddKey(KeyType.GTIN, "00074562000526");

DigitalLink link = builder.Build();
if (!link.IsValid)
{
    Console.WriteLine("Errors:");
    List<ValidationError> errors = link.GetValidationErrors();
    foreach (ValidationError error in errors)
    {
        //Value '00074562000526' does not have a valid check digit. Segment: GTIN - Global Trade Item Number (GTIN).
        Console.WriteLine(error);
    }
}
else
{
    Console.Write("Payload: ");
    //https://www.evebury.com/01/00074562000525?11=260318&3201=002903&3932=9788800&91=value1%2fwith+slash&92=value2
    Console.WriteLine(link.Uri);
}

```
## 🔧 Todo
- Write tests
- Simplify for TradeItem only
- Add a DigitalLink Parser for reading an uri and converting to strongly typed segment values for greater interopability.


## 📋 Requirements & Enterprise support

- **.NET 10.0** or later
- **Dependencies**: None (pure .NET implementation)
> ### 💡 Need a different version?
> While we target .NET 10 for maximum performance, we provide **custom builds and integration support** for organizations running on **any other Framework**.
> [Contact evebury for custom builds or professional services](https://www.evebury.com)



## ℹ️ Help
> Want to learn more about **GS1 DIGITAL LINK** or syndicating your data to **GS1**? Or anything else? We would love to hear from you! Reach out to us at: [Evebury](https://www.evebury.com).


## 📄 License

This project is licensed under the MIT License - see below for details:

```
MIT License

Copyright (c) 2026 Evebury

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

*This library implements the GS1 DigitalLink specification with focus on practical usage.*
