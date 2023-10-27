using System.Text.RegularExpressions;

namespace CarStore.Core.Extensions;

public static class StringExtension
{

    public static string GetWithinCharacterEspecial(this string texto)
    {
        return texto
            .RemoveAccent()
            .RemoveCharacterEspecial();
    }

    public static string RemoveCharacterEspecial(this string texto)
    {
        var caracter = string.Empty;
        var result = string.Empty;

        if (!string.IsNullOrEmpty(texto))
        {
            for (int i = 0; i < texto.ToString().Length; i++)
            {
                caracter = texto[i].ToString();
                switch (caracter)
                {
                    case "&": caracter = string.Empty; break;
                    case "º": caracter = string.Empty; break;
                    case ":": caracter = string.Empty; break;
                    case "@": caracter = string.Empty; break;
                    case "#": caracter = string.Empty; break;
                    case "$": caracter = string.Empty; break;
                    case "%": caracter = string.Empty; break;
                    case "¨": caracter = string.Empty; break;
                    case "*": caracter = string.Empty; break;
                    case "(": caracter = string.Empty; break;
                    case ")": caracter = string.Empty; break;
                    case "ª": caracter = string.Empty; break;
                    case "°": caracter = string.Empty; break;
                    case ";": caracter = string.Empty; break;
                    case "/": caracter = string.Empty; break;
                    case "´": caracter = string.Empty; break;
                    case "`": caracter = string.Empty; break;
                    case "'": caracter = string.Empty; break;
                    case "-": caracter = string.Empty; break;
                    case " ": caracter = string.Empty; break;
                }
                result += caracter;
            }
        }

        return result;
    }

    public static string RemoveAccent(this string texto)
    {
        string caracter;
        var result = string.Empty;

        for (int i = 0; i < texto.ToString().Length; i++)
        {
            caracter = texto[i].ToString();
            switch (caracter)
            {
                case "á": caracter = "a"; break;
                case "é": caracter = "e"; break;
                case "í": caracter = "i"; break;
                case "ó": caracter = "o"; break;
                case "ú": caracter = "u"; break;
                case "à": caracter = "a"; break;
                case "è": caracter = "e"; break;
                case "ì": caracter = "i"; break;
                case "ò": caracter = "o"; break;
                case "ù": caracter = "u"; break;
                case "â": caracter = "a"; break;
                case "ê": caracter = "e"; break;
                case "î": caracter = "i"; break;
                case "ô": caracter = "o"; break;
                case "û": caracter = "u"; break;
                case "ä": caracter = "a"; break;
                case "ë": caracter = "e"; break;
                case "ï": caracter = "i"; break;
                case "ö": caracter = "o"; break;
                case "ü": caracter = "u"; break;
                case "ã": caracter = "a"; break;
                case "õ": caracter = "o"; break;
                case "ñ": caracter = "n"; break;
                case "ç": caracter = "c"; break;
                case "Á": caracter = "A"; break;
                case "É": caracter = "E"; break;
                case "Í": caracter = "I"; break;
                case "Ó": caracter = "O"; break;
                case "Ú": caracter = "U"; break;
                case "À": caracter = "A"; break;
                case "È": caracter = "E"; break;
                case "Ì": caracter = "I"; break;
                case "Ò": caracter = "O"; break;
                case "Ù": caracter = "U"; break;
                case "Â": caracter = "A"; break;
                case "Ê": caracter = "E"; break;
                case "Î": caracter = "I"; break;
                case "Ô": caracter = "O"; break;
                case "Û": caracter = "U"; break;
                case "Ä": caracter = "A"; break;
                case "Ë": caracter = "E"; break;
                case "Ï": caracter = "I"; break;
                case "Ö": caracter = "O"; break;
                case "Ü": caracter = "U"; break;
                case "Ã": caracter = "A"; break;
                case "Õ": caracter = "O"; break;
                case "Ñ": caracter = "N"; break;
                case "Ç": caracter = "C"; break;
                case "£": caracter = ""; break;
                case "©": caracter = ""; break;
                case "¢": caracter = ""; break;
            }
            result += caracter;
        }
        return result;
    }

    public static string? ReplaceCharacterSequencial(this string valor)
    {
        string? result = null;
        try
        {
            var before = '0';
            var newChar = '0';
            var caracters = new char[valor.Length];
            caracters = valor.ToCharArray();

            foreach (char caracter in caracters)
            {
                if (caracter == before)
                    newChar = Convert.ToChar(Convert.ToString(Convert.ToInt16(caracter) + 2 > 9 ? 1 : Convert.ToInt16(caracter) + 2));
                else
                    newChar = caracter;

                before = newChar;
                result += newChar;
            }
        }
        catch { result = null; }

        return result;
    }

    public static string? RemoveCharacters(this string input)
    {
        string? resultString;
        try
        {
            var regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(input, "");
        }
        catch { resultString = null; }

        return resultString;
    }

    public static long RemoveCharactersToInt(this string input)
    {
        string? resultString ;
        try
        {
            var regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(input, "");
        }
        catch { resultString = null; }

        return string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt64(resultString);
    }

    public static string FormatString(this string mascara, string valor)
    {
        var novoValor = string.Empty;
        var posicao = 0;
        for (int i = 0; mascara.Length > i; i++)
        {
            if (mascara[i] == '#')
            {
                if (valor.Length > posicao)
                {
                    novoValor = novoValor + valor[posicao];
                    posicao++;
                }
                else
                    break;
            }
            else
            {
                if (valor.Length > posicao)
                    novoValor = novoValor + mascara[i];
                else
                    break;
            }
        }
        return novoValor;
    }

    public static string ToReplaceWebProtocol(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var webProtocol = new List<string>() { "https://", "http://" };

        webProtocol.ForEach(protocol =>
        {
            if (input.Contains(protocol))
            {
                input = input.Replace(protocol, "");
            }
        });

        return input;
    }

    public static bool ToRemoveLogRequest(this string input)
    {
        var notRemove = true;

        if (string.IsNullOrEmpty(input)) return notRemove;

        var extenssions = new List<string>() { ".json", ".css", ".js", ".gif", ".woff", ".ico", ".svg", ".png", ".map", "hangfire" };

        foreach (var extenssion in extenssions)
        {
            if (input.ToLower().Contains(extenssion))
            {
                notRemove = false;
                break;
            }
        }

        return notRemove;
    }  

    public static string GetOnlyNumber(this string texto)
    {
        return Regex.Replace(texto, "[^0-9,]", "");
    }


    public static string OnlyNumber(this string valor)
    {
        var onlyNumber = "";
        foreach (var s in valor)
        {
            if (char.IsDigit(s))
            {
                onlyNumber += s;
            }
        }
        return onlyNumber.Trim();
    }
    public static string ToSnakeCase(this string name)
        => Regex.Replace(
            name,
            @"([a-z0-9])([A-Z])",
            "$1_$2").ToLower();

}