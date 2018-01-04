# GeekMDSuite ![Build Status][build_status]

A suite of medical software objects and tools designed to compliment preventative medicine practices or practices that employ technologies common to those practices. This is a second version of multiple class libraries, consolidated into a suite and with the concerns more adequately separated for future extensibility.

## GeekMD.Core
A fluent API with objects and tests which serve as the basis of the GeekMDSuite.

## GeekMD.Analytics
A fluent API where one can input objects and receive useful information and clinical decision support.

## GeekMD.WebAPI
The backend RESTful service providing front end developers access to the objects and their respective analytics.

## GeekMD.ConsoleDemo
A simple console application for demonstrating the use of GeekMD.Core.

```cs
var ishiharaSix = IshiharaSixPlateScreenBuilder
                .Initialize()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();

var ishiharaSixInterp = new IshiharaSixPlateClassification(ishiharaSix);
Console.WriteLine(ishiharaSixInterp);
```

[build_status]: http://teamcity.zapto.org:8080/app/rest/builds/buildType:(id:GeekMDApplicationSuite_Build)/statusIcon.svg
