using CarStore.Core.Extensions;

namespace CarStore.Shop.Domain.Validations.Documents;

public static class RenavamValidacao
{

    public const int TamanhoRenavam = 11;

    public static bool Validate(string renavam)
    {
        var number = renavam.OnlyNumber();

        if (!SizeValid(number)) return false;
        return !HasRepeatedDigits(number) && HaveValidDigits(number);
    }

    private static bool SizeValid(string value) => value.Length == TamanhoRenavam;

    private static bool HasRepeatedDigits(string value)
    {
        string[] invalidNumbers =
        {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
        return invalidNumbers.Contains(value);
    }

    private static bool HaveValidDigits(string renavam)
    {
        if (string.IsNullOrEmpty(renavam.Trim())) return false;

        var digits = new int[11];

        var value = 0;

        for (int i = 0; i < 11; i++)
            digits[i] = Convert.ToInt32(renavam.Substring(i, 1));

        for (int i = 0; i < 10; i++)
            value += digits[i] * Convert.ToInt32(renavam.Substring(i, 1));

        value = (value * 10) % 11; value = (value != 10) ? value : 0;
        return (value == digits[10]);
    }
}