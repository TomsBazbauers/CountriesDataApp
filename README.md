# CountriesDataApp
A simple WebAPI app that consumes from a REST API service, filters and returns data about countries by request.

### Description:

 - Consumes data from https://restcountries.com/
 - Built on .NET6
 - Additional packages installed: 
```
Refit(6.3.2) 
Refit.HttpClientFactory(6.3.2) 
AutoMapper(12.0.0) 
Newtonsoft.Json(13.0.2)
```
### Unit-tests:
- Test done via xUnit (2.4.1)
- Additional packages installed:
```
Moq(4.18.3)
FluentAssertions(6.8.0)
```

### How to run:

*An IDE (code editor) with C#/.NET support (MS Visual Studio or JetBrains Rider, etc.) is necessary to run this app!
(I'm using MS Visual Studio 2022)*

**When your IDE is ready:**

1. Clone or download this repository:
```
https://github.com/TomsBazbauers/CountriesDataApp
```

2. Run the solution file:

```
CountriesDataApp.sln
```

3. If there are some errors, it might be due to missing packages:

```
Refit(6.3.2) or Refit.HttpClientFactory(6.3.2) or AutoMapper(12.0.0) or Newtonsoft.Json(13.0.2)
```

4. In your IDE choose startup project *CountriesDataApp.API* (set by default) and click **Run Project**:

![RunProject](https://user-images.githubusercontent.com/104777985/205559997-8cb9f27b-25d0-4613-acd6-e89329d8d880.png)

5. A *Swagger* page should open with both of the controller endpoints visible:

- For Top 10 EU countries **by population**, or set **byDensity** *true* for Top 10 EU countries by **population density**:
```
GET > api/CountriesControllerEU/european-union/population/top10
```
- For only data about a certain country:
```
GET > api/CountriesControllerEU/{name}
```

![SwaggerPage](https://user-images.githubusercontent.com/104777985/205560531-1b89b89d-340a-4f7d-8378-4b110461ce77.png)

6. To get population data:

```
Get Top 10 EU countries by population: 'Try it out' > 'Execute' 

Get Top 10 EU countries by population density: 'Try it out' > byDensity set 'TRUE' > 'Execute' 
```

7. To get data about a specific country:

```
'Try it out' > set NAME as any country you wish to get data on > 'Execute'
```

### How to run tests:

1. If there are some errors, it might be due to missing packages:

```
xunit(2.4.1) or xunit.runner.visualstudio(2.4.3) or Moq(4.18.3) or FluentAssertions(6.8.0)
```
- Open the *Test* menu, click **Run All Tests**:

![RunAllTests](https://user-images.githubusercontent.com/104777985/205559002-16497cb9-c733-4a6f-8607-4b233a663b64.png)

- A Test Explorer window will open and you'll see which tests *passed* and which *failed*:

![TestExplorer](https://user-images.githubusercontent.com/104777985/205559459-a95d95df-0301-4410-9cde-b45e39178926.png)

