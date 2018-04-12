# CorrelationService
This WebAPI service based on ASP.NET Core can calculate Kendall and Pearson correlation coefficients. It can work with tabulated and analytic functions.

## Examples
URL: http:/<<host:port>>/api/correlation/numeric  
Content-Type: application/json  
Type: POST  
Body:  
`{
  "type": "Pearson",
  "function1": {
    "points": [
      {
        "x": -3.1415926535897931,
        "y": -1.2246467991473532E-16
      },
      {
        "x": -2.4434609527920612,
        "y": -0.64278760968653947
      },
      {
        "x": -1.7453292519943293,
        "y": -0.98480775301220813
      },
      {
        "x": -1.0471975511965974,
        "y": -0.86602540378443849
      },
      {
        "x": -0.34906585039886562,
        "y": -0.34202014332566844
      },
      {
        "x": 0.34906585039886617,
        "y": 0.342020143325669
      },
      {
        "x": 1.0471975511965979,
        "y": 0.86602540378443871
      },
      {
        "x": 1.7453292519943298,
        "y": 0.984807753012208
      },
      {
        "x": 3.1415926535897931,
        "y": 1.2246467991473532E-16
      }
    ]
  },
  "function2": {
    "points": [
      {
        "x": -3.1415926535897931,
        "y": -1.0
      },
      {
        "x": -2.4434609527920612,
        "y": -0.7660444431189779
      },
      {
        "x": -1.7453292519943293,
        "y": -0.17364817766693008
      },
      {
        "x": -1.0471975511965974,
        "y": 0.50000000000000033
      },
      {
        "x": -0.34906585039886562,
        "y": 0.93969262078590854
      },
      {
        "x": 0.34906585039886617,
        "y": 0.93969262078590832
      },
      {
        "x": 1.0471975511965979,
        "y": 0.49999999999999989
      },
      {
        "x": 1.7453292519943298,
        "y": -0.17364817766693053
      },
      {
        "x": 3.1415926535897931,
        "y": -1.0
      }
    ]
  }
}`
Response:  
`{
    "value": 0.1068257880599552,
    "executionTime": 1
}`

URL: http:/<<host:port>>/api/correlation/analytic  
Content-Type: application/json  
Type: POST  
Body:  
`{
  "type": "Pearson",
  "function1": "Cos(x)",
  "function2": "Sin(x)",
  "leftBorder": -3,
  "rightBorder": 6,
  "pointsCount": 100
}`
Response:  
`{
    "value": -0.0016290537428206339,
    "executionTime": 50
}`

URL: http:/<<host:port>>/api/correlation/analytic  
Content-Type: application/json  
Type: POST  
Body:  
`{
  "type": "Pearson",
  "function1": "Pow(x)",  //error is here
  "function2": "Sin(x)",
  "leftBorder": -3,
  "rightBorder": 6,
  "pointsCount": 100
}`
Response:  
`{
    "value": 0,
    "executionTime": 43,
    "error": "(1,6): error CS7036: There is no argument given that corresponds to the required formal parameter 'y' of 'Math.Pow(double, double)'"
}`
