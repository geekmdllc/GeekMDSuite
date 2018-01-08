# GeekMDSuite ![Build Status][build_status]

A suite of medical software objects and tools designed to compliment preventative medicine practices or practices that employ technologies common to those practices. This is a second version of multiple class libraries, consolidated into a suite and with the concerns more adequately separated for future extensibility.

## GeekMD.Core
A fluent API with objects and tests which serve as the basis of the GeekMDSuite.

## GeekMD.Analytics
A fluent API where one can input objects and receive useful information and clinical decision support.

## GeekMD.WebAPI
The backend RESTful service providing front end developers access to the objects and their respective analytics.

Example API endpoint:
```text
http://localhost:5000/app/rest/classify/composite/ascvd/
```
POST
```json
{
    "patient": {
        "dateOfBirth": "1990-01-01T00:00:00",
        "age": 28,
        "name": {
            "first": "Test",
            "middle": "",
            "last": "Patient",
            "isMalformed": false
        },
        "medicalRecordNumber": "132121234",
        "gender": {
            "category": 1,
            "genotype": 0
        },
        "race": 6,
        "comorbidities": [
            0,
            1
        ]
    },
    "bloodPressure": {
        "systolic": 155,
        "diastolic": 90,
        "organDamage": false
    },
    "totalCholesterol": {
        "result": 263,
        "type": 12,
        "measurementSystem": 0
    },
    "ldlCholesterol": {
        "result": 153,
        "type": 33,
        "measurementSystem": 0
    },
    "hdlCholesterol": {
        "result": 35,
        "type": 25,
        "measurementSystem": 0
    }
}
```
REPLY
```json
{
    "tenYearRiskPercentage": 15.773348794393815,
    "idealTenYearRiskPercentage": 0.12108465625320086,
    "tenYearRiskClassification": 2,
    "lifetimeRiskPercentage": 50,
    "idealLifetimeRiskPercentage": 8,
    "lifetimeRiskClassification": 2,
    "statinCandidacy": 2,
    "statinRecommendation": 3,
    "aspirinRecommendation": 2,
    "riskFactors": [
        4,
        0,
        2,
        1
    ]
}
```

## GeekMD.ConsoleDemo
A simple console application for demonstrating the use of GeekMD.Core.

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

var classification = new IshiharaSixPlateClassification(test);
Console.WriteLine(classification);
```

[build_status]: http://teamcity.zapto.org:8080/app/rest/builds/buildType:(id:GeekMDApplicationSuite_Build)/statusIcon.svg
