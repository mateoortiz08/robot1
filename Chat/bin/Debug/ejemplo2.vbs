Option Explicit

Dim xlApp, xlBook

Set xlApp = CreateObject("Excel.Application")
xlApp.DisplayAlerts = False
Set xlBook = xlApp.Workbooks.Open("C:\Users\edison.guirales\Documents\edison.xlsm", 0, false)

xlApp.Run "Macro1"

xlBook.Close true
xlApp.Quit

Set xlBook = Nothing
Set xlApp = Nothing

WScript.Echo "Finished."
WScript.Quit