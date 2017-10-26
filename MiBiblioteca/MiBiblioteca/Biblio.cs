using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiBiblioteca
{
    public class Nif
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("hola");
        }
        public static bool ValidaNif(string nif)
        {
            nif = nif.ToUpper();
            if (!Regex.IsMatch(nif, "[0-9]{7,8}[TRWAGMYFPDXBNJZSQVHLCKE]")) return false;
            else if (Nif.CalculaLetra(int.Parse(nif.Substring(0, nif.Length - 1))) != nif[nif.Length - 1]) return false;
            else return true;

        }

        public static char CalculaLetra(int num)
        {
            return "TRWAGMYFPDXBNJZSQVHLCKE"[num % 23];
        }
    }

    public class Burocracia
    {
        public static string NumeroALetras(int num)
        {
            string numeritos = num.ToString();
            int[] numDiv = new int[(numeritos.Length / 3) + (numeritos.Length % 3 != 0 ? 1 : 0)];
            for (int i = 0; i < numDiv.Length; i++)
            {
                numDiv[i] = num % 1000;
                num = (int)num / 1000;
            }
            string sol = "";
            Console.WriteLine(numDiv.Length);
            for (int i = 0; i < numDiv.Length; i++)
            {
                //if (num != 0 && i != numDiv.Length - 1) sol += " ";
                sol = NumALet(numDiv[i], i) + ExpALet(numDiv[i], i) + sol;
            }
            return sol + "|";
        }

        /// <summary>
        /// </summary>
        /// <param name="num">Numero de 3 cifras que se quiere pasar a letra</param>
        /// <param name="exp">Exponente de 100 del numero</param>
        /// <returns>Un string que contiene el resultado</returns>
        public static string NumALet(int num, int exp)
        {
            int cent = (int)num / 100;
            int dec = (int)(num % 100) / 10;
            int uni = num % 10;
            string sol = "";
            if (num == 100) return "cien";
            if (num == 1) return "";
            switch (cent)
            {
                case 1: sol += "ciento"; break;
                case 2: sol += "doscientos"; break;
                case 3: sol += "trescientos"; break;
                case 4: sol += "cuatrocientos"; break;
                case 5: sol += "quinientos"; break;
                case 6: sol += "seiscientos"; break;
                case 7: sol += "setecientos"; break;
                case 8: sol += "ochocientos"; break;
                case 9: sol += "novecientos"; break;
                default: sol += ""; break;
            }
            sol += (cent != 0 && (dec > 0 || uni > 0) ? " " : "");
            switch (dec)
            {
                case 1: sol += (uni == 0 ? "diez" : "dieci"); break;
                case 2: sol += (uni == 0 ? "diez" : "veinti"); break;
                case 3: sol += "treinta" + (uni != 0 ? " y" : ""); break;
                case 4: sol += "cuarenta" + (uni != 0 ? " y" : ""); break;
                case 5: sol += "cincuenta" + (uni != 0 ? " y" : ""); break;
                case 6: sol += "sesenta" + (uni != 0 ? " y" : ""); break;
                case 7: sol += "setenta" + (uni != 0 ? " y" : ""); break;
                case 8: sol += "ochenta" + (uni != 0 ? " y" : ""); break;
                case 9: sol += "noventa" + (uni != 0 ? " y" : ""); break;
                default: sol += ""; break;
            }
            sol += (dec != 0 && uni > 0 ? " " : "");
            switch (uni)
            {
                case 1: sol += (exp == 0 ? "uno" : "un"); break;
                case 2: sol += "dos"; break;
                case 3: sol += "tres"; break;
                case 4: sol += "cuatro"; break;
                case 5: sol += "cinco"; break;
                case 6: sol += "seis"; break;
                case 7: sol += "siete"; break;
                case 8: sol += "ocho"; break;
                case 9: sol += "nueve"; break;
                default: sol += ""; break;
            }
            return sol + " ";
        }

        public static string ExpALet(int num, int exp)
        {
            if (num == 0) return "";
            switch (exp)
            {
                case 1: return (num == 1 ? "" : " ") + "mil";
                case 2: return (num == 1 ? "un " : "") + "millon" + (num == 1 ? "" : "es");
                case 3: return "mil millones";
                case 4: return (num == 1 ? "un " : "") + "billon" + (num == 1 ? "" : "es");
                default: return "";
            }
        }
    }

    public class Matematicas
    {
        public static int Suma(int a, int b)
        {
            return (a + b);
        }
        public static int Multiplica(int a, int b)
        {
            return (a * b);
        }
    }
    public class Texto
    {
        public static bool Palindromo(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - i - 1])
                    return false;
            return true;
        }
    }
}
