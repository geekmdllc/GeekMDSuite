# GeekMDSuite ![Build Status][build_status]

A software suite designed to compliment preventative medicine practices or practices that employ technologies common to those practices. Core and Analytics API users will find complex object creation to be simple. The web API is robust, serves XML and JSON, provides API endpoints for persistence of core objects, and analytics modules which can be extended to web API users who do not have patient data in our persistence infrastructure. 

## GeekMD.Core
A fluent API with objects and tests which serve as the basis of the GeekMDSuite.
```cs
var test = IshiharaSixPlateScreenBuilder
                .Initialize()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();
```

## GeekMD.Analytics
A fluent API where one can input objects and receive useful information and clinical decision support.
```cs
var classification = new IshiharaSixPlateClassification(test);
```

## GeekMD.ConsoleDemo
A simple console application for demonstrating the use of GeekMD.Core. Utilizes core and analytics.
```cs
Console.WriteLine(classification);
```
Result:
```text
Ishihara 6 Plate: ColorVisionDeficit
```
