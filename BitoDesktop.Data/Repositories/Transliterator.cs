using System;
using System.Collections.Generic;
using System.Text;

namespace BitoDesktop.Data.Repositories;

internal class Transliterator
{

    public static Dictionary<Int32, Int32> lToC;
    public static Dictionary<Int32, Int32> cToL;

    private string str;
    private bool? isLatin = null;

    public Transliterator(string str)
    {
        this.str = str?.ToLower();

        if (this.str != null)
        {
            var latinCount = 0;
            var cyrillicCount = 0;

            foreach (var it in this.str)
            {
                if (97 <= it && it <= 122)
                    latinCount++;
                else if (1072 <= it && it <= 1094 || 1098 <= it && it <= 1101 || it == 1179 || it == 1203)
                    cyrillicCount++;
            }

            if (latinCount != 0 && cyrillicCount != 0)
                isLatin = null;
            else
                isLatin = latinCount != 0;
        }
    }

    public string Native() => str ?? "";

    public string Transliterated() => isLatin == null ? (str ?? "") : isLatin == true ? ToCryllic() : ToLatin();

    public string ToCryllic()
    {
        if (str == null)
            return "";

        int size = str.Length;
        if (size == 0) return "";

        if (isLatin != true)
            return str;

        var stringBuilder = new StringBuilder();

        var index = 0;
        while (index != size)
        {
            var code = str[index];
            var nextCode = index == size - 1 ? 0 : str[index + 1];

            if (code == 99 && nextCode == 104)
            {
                stringBuilder.Append('ч');
                index++;
            }
            else if (code == 115 && nextCode == 104)
            {
                stringBuilder.Append('ш');
                index++;
            }
            else if (code == 111 && nextCode == 39)
            {
                stringBuilder.Append('ў');
                index++;
            }
            else if (code == 103 && nextCode == 39)
            {
                stringBuilder.Append('ғ');
                index++;
            }
            else
            {
                Int32 _code = code;
                if (lToC.ContainsKey(code))
                    _code = lToC[code];

                stringBuilder.Append((char)_code);
            }

            index++;
        }

        return stringBuilder.ToString();
    }

    public string ToLatin()
    {
        if (str == null)
            return "";

        int size = str.Length;
        if (size == 0) return "";
        if (isLatin != false)
            return str;

        var stringBuilder = new StringBuilder();

        var index = 0;
        while (index != size)
        {
            var code = str[index];

            if (code == 1095)
                stringBuilder.Append("ch");
            else if (code == 1096 || code == 1097)
                stringBuilder.Append("sh");
            else if (code == 1102)
                stringBuilder.Append("yu");
            else if (code == 1103)
                stringBuilder.Append("ya");
            else if (code == 1171)
                stringBuilder.Append("g'");
            else if (code == 1118)
                stringBuilder.Append("o'");
            else
            {
                Int32 _code = code;
                if (lToC.ContainsKey(code))
                    _code = lToC[code];
                stringBuilder.Append((char)_code);
            }

            index++;
        }

        return stringBuilder.ToString();
    }


    static Transliterator()
    {
        lToC.Add(97, 1072);       // a
        lToC.Add(98, 1073);       // b
        lToC.Add(99, 1089);       // c
        lToC.Add(100, 1076);      // d
        lToC.Add(101, 1101);      // e
        lToC.Add(102, 1092);      // f
        lToC.Add(103, 1075);      // g
        lToC.Add(104, 1203);      // h
        lToC.Add(105, 1080);      // i
        lToC.Add(106, 1078);      // j
        lToC.Add(107, 1082);      // k
        lToC.Add(108, 1083);      // l
        lToC.Add(109, 1084);      // m
        lToC.Add(110, 1085);      // n
        lToC.Add(111, 1086);      // o
        lToC.Add(112, 1087);      // p
        lToC.Add(113, 1179);      // q
        lToC.Add(114, 1088);      // r
        lToC.Add(115, 1089);      // s
        lToC.Add(116, 1090);      // t
        lToC.Add(117, 1091);      // u
        lToC.Add(118, 1074);      // v
        lToC.Add(119, 1074);      // w
        lToC.Add(120, 1093);      // x
        lToC.Add(121, 1081);      // y
        lToC.Add(122, 1079);      // z

        cToL.Add(1072, 97);       // а
        cToL.Add(1073, 98);       // б
        cToL.Add(1074, 118);      // в
        cToL.Add(1075, 103);      // г
        cToL.Add(1076, 100);      // д
        cToL.Add(1077, 101);      // е
        cToL.Add(1078, 106);      // ж
        cToL.Add(1079, 122);      // з
        cToL.Add(1080, 105);      // и
        cToL.Add(1081, 121);      // й
        cToL.Add(1082, 107);      // к
        cToL.Add(1083, 108);      // л
        cToL.Add(1084, 109);      // м
        cToL.Add(1085, 110);      // н
        cToL.Add(1086, 111);      // о
        cToL.Add(1087, 112);      // п
        cToL.Add(1088, 114);      // р
        cToL.Add(1089, 115);      // с
        cToL.Add(1090, 116);      // т
        cToL.Add(1091, 117);      // у
        cToL.Add(1092, 102);      // ф
        cToL.Add(1093, 120);      // х
        cToL.Add(1094, 115);      // ц
        cToL.Add(1100, 0);        // ь
        cToL.Add(1098, 0);        // ъ
        cToL.Add(1099, 105);      // ы
        cToL.Add(1101, 101);      // э
        cToL.Add(1203, 104);      // ҳ
        cToL.Add(1179, 113);      // қ
    }


}

