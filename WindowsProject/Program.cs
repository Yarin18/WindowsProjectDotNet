using System;
using System.Linq;
using System.Collections.Generic;
namespace WindowsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // pairs is een dictionairy die een conversie karakter met de naam opslaat.
            Dictionary<String, String> pairs = new Dictionary<string, string>();
            pairs["c"] = "Celcius"; // "c" representeerd "Celcius"
            pairs["k"] = "Kelvin"; // "k" representeerd "Kelvin"
            pairs["f"] = "Fahrenheit"; //"f" representeerd "Fahrenheit"

            // Stuur een bericht dat vraagt van welke waarde iemand de temperatuur wilt converteren.
            Console.WriteLine("What do you want to convert from? Options (Celcius: c) (Kelvin: k) (Fahrenheit: f)");
            // sla de ingegeven waarden op
            String convertFrom = Console.ReadLine();
            if(!pairs.Keys.Contains(convertFrom)) // als de ingegeven waarden niet in de "Keys" van de dictionary zit ("c", "k", "f"), dan stuur dat het invalid is.
            {
                Console.WriteLine("Invalid conversion character!"); // invalid conversie karakter ingegeven, stop het programma
                return;
            }
            // vragen naar welke temperatuur waarde de persoon het in wilt omzetten
            Console.WriteLine("What do you want to convert to? Options (Celcius: c) (Kelvin: k) (Fahrenheit: f)");
            // sla de ingegeven waarden op.
            String convertTo = Console.ReadLine();
           // kijken of de keys van de dictionairy de ingegeven waarden van de gebruiker bevat.
            if(!pairs.Keys.Contains(convertTo))
            {
                Console.WriteLine("Invalid conversion character!"); // invalid conversie karakter ingegeven, stop het programma
                return;
            }
            // vraag de gebruiker hoeveel in de waarde van de "convertFrom" variable de gebruiker wilt omzetten naar de "convertTo" temperatuur.
            Console.WriteLine("What is the amount you want to convert?");
            try // probeer de input van de gebruiker om te zetten naar een "double" datatype
            {
                // vervang alle punten met kommas, zo kan je zowel "10,5" als "10.5" ingeven.
                String amount = Console.ReadLine().Replace(".", ",");
                double result = convertValues(convertFrom, convertTo, double.Parse(amount)); // parse de String naar een Double.

                // Stuur een bericht met dat de conversie successvol was, met het uiteindelijke resultaat
                Console.WriteLine("Conversion from " + convertFrom + " to " + convertTo + " was successful!");
                Console.WriteLine(amount + " " + pairs[convertFrom] + " is " + result + " " + pairs[convertTo]);
            } catch (FormatException e) // De String kon niet omgezet worden naar een double, stuur een error bericht en stop het programma
            {   
                Console.WriteLine("This is not a numeric value!");
                return;
            }
            Console.ReadLine();
        }

        // methode voor het omzetten en berkeken van de temperaturen
        private static double convertValues(String from, String to, double amount)
        {
            switch (from)
            {
                case "c":
                    if (to == "k") // from celcius to kelvin
                    {
                        return amount + 273.15;
                    }
                    else if (to == "f") // from celcius to fahrenheit
                    {
                        return amount * 9/5 + 32;
                    }
                    else return amount; // from fahrenheit to celcius
                case "k":
                    if (to == "c") // kelvin to celcius
                    {
                        return amount - 273.15;
                    }
                    else if (to == "f") // kelvin to fahrenheit
                    {
                        return 1.8 * (amount - 273) + 32;
                    }
                    else return amount; // kelvin to kelvin
                case "f":
                    if (to == "c")
                    {
                        return (amount - 32) * 5 / 9;
                    }
                    else if (to == "k")
                    {
                        return (amount - 32) *5 / 9 + 273.15;
                    }
                    else return amount; // fahrenheit to fahreneit             
                default:
                    return 0;
                 
            }
        }
    }

    
}
