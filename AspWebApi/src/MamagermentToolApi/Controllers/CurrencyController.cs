namespace WebForms
{
using CurrencyCalculatorAngularJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

public class CurrencyController : ApiController
{
[HttpGet]
[ActionName("convertcurrency")]
public Double ConvertCurrency(string incurrcode,string incurrvalue,string outcurrcode)
{
  string currencyUrl = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
  string rate = "";
  string incurrcodetoeuro="";
  string outcurrcodetoeuro="";

  Double outcurrencyvalue = 0;
  try
  {
   if (incurrvalue.Equals("0"))
   {                    
      outcurrencyvalue = 0;
   }
   else
   {
    // If input currency code and output currency code are same then return
    // currency value as output currency value
    if (incurrcode.Equals(outcurrcode))
    {
       outcurrencyvalue = Convert.ToDouble(incurrvalue);
    }
    else
    {
 //Fetch Currency Feed XML File
 XDocument xmlDoc = XDocument.Load(currencyUrl);
 foreach (XElement element in xmlDoc.Root.Descendants())
 {
   XName name = element.Name;
   if (name.LocalName == "Cube")
   {
    foreach (XElement elem in element.DescendantNodes())
    {
     //string time = elem.Attribute("time").Value;
     foreach (XElement element1 in elem.DescendantNodes())
     {
  if (element1.Attribute("currency").Value.Equals(incurrcode))
         {
      // the value of 1 equivalent euro to input currency
      //ex input currency code as "USD", 1 EURO = 1.36 USD
             // then, incurrcodetoeuro = 1.36
      incurrcodetoeuro = element1.LastAttribute.Value.ToString();
  }
  else if (element1.Attribute("currency").Value.Equals(outcurrcode))
  {
    // the value of 1 equivalent euro 
           // ex output currency code as "USD", 1 EURO = 1.36 USD
    // then, outcurrcodetoeuro = 1.36
    outcurrcodetoeuro = element1.LastAttribute.Value.ToString();
          }

        }

     }
         }

        }

 // Since the base currency is euro, return outcurrcodetoeuro
 // if the input currency code is equal to "EUR" (Euro)
     
 if (incurrcode.Equals("EUR"))
 {
   rate = outcurrcodetoeuro;
   Double currVal = Convert.ToDouble(rate) * Convert.ToDouble(incurrvalue);                            
          outcurrencyvalue = currVal;
        }

 // If output currency code is "EUR
 // return value = (1/incurrcodetoeuro) * the value to be converted

 else if (outcurrcode.Equals("EUR"))
 {
   rate = incurrcodetoeuro;
   Double currVal = (1 / Convert.ToDouble(rate)) * Convert.ToDouble(incurrvalue);                            
   outcurrencyvalue = currVal;

 }
     
 // return value = 1/incurrcodetoeuro * outcurrcodetoeuro * the value to be converted

 else
        {
   Double fromVal = Convert.ToDouble(incurrcodetoeuro);
   Double toVal = Convert.ToDouble(outcurrcodetoeuro);
   Double baseResult = (1 / fromVal);
   Double currVal = baseResult * toVal * Convert.ToDouble(incurrvalue);                            
   outcurrencyvalue = currVal;
 }
      }
    }
   //Return coverted currency value rounded to 4 decimals
   return Math.Round(outcurrencyvalue, 4);
  }
  catch (FormatException fex)
  {
      return 0;
  }                      
}
}
}
