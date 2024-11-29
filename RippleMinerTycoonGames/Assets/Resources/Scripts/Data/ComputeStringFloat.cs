using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class ComputeStringFloat : ComputeStringInt
{
    public static int DividResaultPrecision = 3;
    private long DotIndex = 0;
    private string BodyNoDotNoSignal = "0";

    public string IntPart
    {
        get
        {
            if (this.DotIndex <= 0L)
                return "0";
            return this.BodyNoDotNoSignal.Substring(0, (int)this.DotIndex);
        }
    }

    public string FloatPart
    {
        get
        {
            if (this.DotIndex == (long)this.BodyNoDotNoSignal.Length)
                return "0";
            if (this.DotIndex == 0L)
                return this.BodyNoDotNoSignal;
            if (this.DotIndex >= 0L)
                return this.BodyNoDotNoSignal.Substring((int)this.DotIndex);
            string str = this.BodyNoDotNoSignal;
            for (int index = 0; (long)index < -this.DotIndex; ++index)
                str = str.Insert(0, "0");
            return str;
        }
    }

    public int IntPartLength
    {
        get
        {
            return this.IntPart.Length;
        }
    }

    public int FloatPartLength
    {
        get
        {
            if (this.FloatPart.Length == 1 && (int)this.FloatPart[0] == 48)
                return 0;
            return this.FloatPart.Length;
        }
    }

    public ComputeStringFloat()
    {
        this.DotIndex = 1L;
        this.Body = "0";
        this.BodyNoDotNoSignal = "0";
    }

    public ComputeStringFloat(string body)
    {
        if (string.IsNullOrEmpty(body))
            this.Body = "0";
        else
            this.Body = this.Trim(body);
        Match match = Regex.Match(this.Body, "[1-9]");
        int num = this.Body.IndexOf('.');
        this.DotIndex = num < 0 ? (long)(this.Body.Length - match.Index) : (num <= match.Index ? (long)(num - match.Index + 1) : (long)(num - match.Index));
        this.BodyNoDotNoSignal = this.Body.Substring(match.Index);
        int startIndex = this.BodyNoDotNoSignal.IndexOf('.');
        if (startIndex >= 0)
            this.BodyNoDotNoSignal = this.BodyNoDotNoSignal.Remove(startIndex, 1);
        this.BodyNoDotNoSignal = base.Trim(this.BodyNoDotNoSignal);
    }

    public static implicit operator string(ComputeStringFloat source)
    {
        return source.Body;
    }

    public static implicit operator ComputeStringFloat(long real)
    {
        return new ComputeStringFloat(real.ToString());
    }

    public static implicit operator ComputeStringFloat(string real)
    {
        return new ComputeStringFloat(real);
    }

    public static bool operator >(ComputeStringFloat left, ComputeStringFloat right)
    {
        if (left.IsPositive && right.IsPositive)
        {
            if (new ComputeStringInt(left.IntPart) < new ComputeStringInt(right.IntPart))
                return false;
            if (new ComputeStringInt(left.IntPart) > new ComputeStringInt(right.IntPart))
                return true;
            int length1 = left.FloatPart.Length;
            int length2 = right.FloatPart.Length;
            string floatPart1 = left.FloatPart;
            string floatPart2 = right.FloatPart;
            if (length1 > length2)
            {
                for (int index = length2; index < length1; ++index)
                    floatPart2 += "0";
            }
            else if (length1 < length2)
            {
                for (int index = length1; index < length2; ++index)
                    floatPart1 += "0";
            }
            return new ComputeStringInt(floatPart1) > new ComputeStringInt(floatPart2);
        }
        return left.IsPositive && !right.IsPositive || (left.IsPositive || !right.IsPositive) && (!left.IsPositive && !right.IsPositive && new ComputeStringFloat((string)right.Absolute()) > new ComputeStringFloat((string)left.Absolute()));
    }

    public static bool operator <(ComputeStringFloat left, ComputeStringFloat right)
    {
        return right > left;
    }

    public static bool operator ==(ComputeStringFloat left, ComputeStringFloat right)
    {
        return !(left > right) && !(left < right);
    }

    public static bool operator !=(ComputeStringFloat left, ComputeStringFloat right)
    {
        return left > right || left < right;
    }

    public static bool operator >=(ComputeStringFloat left, ComputeStringFloat right)
    {
        return left > right || left == right;
    }

    public static bool operator <=(ComputeStringFloat left, ComputeStringFloat right)
    {
        return left < right || left == right;
    }

    public static bool operator >(ComputeStringFloat left, object right)
    {
        return left > new ComputeStringFloat(right.ToString());
    }

    public static bool operator >(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) > right;
    }

    public static bool operator <(ComputeStringFloat left, object right)
    {
        return left < new ComputeStringFloat(right.ToString());
    }

    public static bool operator <(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) < right;
    }

    public static bool operator ==(ComputeStringFloat left, object right)
    {
        return left == new ComputeStringFloat(right.ToString());
    }

    public static bool operator ==(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) == right;
    }

    public static bool operator !=(ComputeStringFloat left, object right)
    {
        return left != new ComputeStringFloat(right.ToString());
    }

    public static bool operator !=(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) != right;
    }

    public static bool operator >=(ComputeStringFloat left, object right)
    {
        return left >= new ComputeStringFloat(right.ToString());
    }

    public static bool operator >=(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) >= right;
    }

    public static bool operator <=(ComputeStringFloat left, object right)
    {
        return left <= new ComputeStringFloat(right.ToString());
    }

    public static bool operator <=(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) <= right;
    }

    public static ComputeStringFloat operator +(ComputeStringFloat left, ComputeStringFloat right)
    {
        if (left == (ComputeStringFloat)0L)
            return right;
        if (right == (ComputeStringFloat)0L)
            return left;
        string numStr1 = left.Body;
        int startIndex1 = numStr1.IndexOf('.');
        if (startIndex1 >= 0)
            numStr1 = numStr1.Remove(startIndex1, 1);
        string numStr2 = right.Body;
        int startIndex2 = numStr2.IndexOf('.');
        if (startIndex2 >= 0)
            numStr2 = numStr2.Remove(startIndex2, 1);
        int length1 = left.FloatPart.Length;
        if (right.FloatPart.Length > length1)
        {
            length1 = right.FloatPart.Length;
            if (left.FloatPart == "0")
            {
                for (int length2 = left.FloatPart.Length; length2 <= length1; ++length2)
                    numStr1 += "0";
            }
            else
            {
                for (int length2 = left.FloatPart.Length; length2 < length1; ++length2)
                    numStr1 += "0";
            }
        }
        else if (right.FloatPart == "0")
        {
            for (int length2 = right.FloatPart.Length; length2 <= length1; ++length2)
                numStr2 += "0";
        }
        else
        {
            for (int length2 = right.FloatPart.Length; length2 < length1; ++length2)
                numStr2 += "0";
        }
        ComputeStringInt computeStringInt = new ComputeStringInt(numStr1) + new ComputeStringInt(numStr2);
        if (computeStringInt.Length == length1)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - length1, "0.");
        if (computeStringInt.Length >= length1)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - length1, ".");
        string str = (string)computeStringInt.Absolute();
        for (int length2 = str.Length; length2 < length1; ++length2)
            str = "0" + str;
        if (computeStringInt.IsPositive)
            return (ComputeStringFloat)str.Insert(0, "0.");
        return (ComputeStringFloat)str.Insert(0, "-0.");
    }

    public static ComputeStringFloat operator -(ComputeStringFloat left, ComputeStringFloat right)
    {
        if (right == (ComputeStringFloat)0L)
            return left;
        if (right.IsPositive)
            return left + (ComputeStringFloat)right.Absolute().Body.Insert(0, "-");
        return left + right.Absolute();
    }

    public static ComputeStringFloat operator *(ComputeStringFloat left, ComputeStringFloat right)
    {
        string numStr1 = left.Body;
        int startIndex1 = numStr1.IndexOf('.');
        if (startIndex1 >= 0)
            numStr1 = numStr1.Remove(startIndex1, 1);
        string numStr2 = right.Body;
        int startIndex2 = numStr2.IndexOf('.');
        if (startIndex2 >= 0)
            numStr2 = numStr2.Remove(startIndex2, 1);
        int floatPartLength1 = left.FloatPartLength;
        if (right.FloatPartLength > floatPartLength1)
        {
            floatPartLength1 = right.FloatPartLength;
            for (int floatPartLength2 = left.FloatPartLength; floatPartLength2 < floatPartLength1; ++floatPartLength2)
                numStr1 += "0";
        }
        else if (right.FloatPartLength < floatPartLength1)
        {
            for (int floatPartLength2 = right.FloatPartLength; floatPartLength2 < floatPartLength1; ++floatPartLength2)
                numStr2 += "0";
        }
        ComputeStringInt computeStringInt = new ComputeStringInt(numStr1) * new ComputeStringInt(numStr2);
        int num = floatPartLength1 + floatPartLength1;
        if (computeStringInt.Length == num)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - num, "0.");
        if (computeStringInt.Length >= num)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - num, ".");
        string str = (string)computeStringInt.Absolute();
        for (int length = str.Length; length < num; ++length)
            str = "0" + str;
        if (computeStringInt.IsPositive)
            return (ComputeStringFloat)str.Insert(0, "0.");
        return (ComputeStringFloat)str.Insert(0, "-0.");
    }

    public static ComputeStringFloat operator /(ComputeStringFloat left, ComputeStringFloat right)
    {
        string numStr1 = left.Body;
        int startIndex1 = numStr1.IndexOf('.');
        if (startIndex1 >= 0)
            numStr1 = numStr1.Remove(startIndex1, 1);
        string numStr2 = right.Body;
        int startIndex2 = numStr2.IndexOf('.');
        if (startIndex2 >= 0)
            numStr2 = numStr2.Remove(startIndex2, 1);
        int floatPartLength1 = left.FloatPartLength;
        if (right.FloatPartLength > floatPartLength1)
        {
            int floatPartLength2 = right.FloatPartLength;
            for (int floatPartLength3 = left.FloatPartLength; floatPartLength3 < floatPartLength2; ++floatPartLength3)
                numStr1 += "0";
        }
        else if (right.FloatPartLength < floatPartLength1)
        {
            for (int floatPartLength2 = right.FloatPartLength; floatPartLength2 < floatPartLength1; ++floatPartLength2)
                numStr2 += "0";
        }
        for (int index = 0; index < ComputeStringFloat.DividResaultPrecision; ++index)
            numStr1 += "0";
        ComputeStringInt computeStringInt = new ComputeStringInt(numStr1) / new ComputeStringInt(numStr2);
        int num = ComputeStringFloat.DividResaultPrecision;
        if (computeStringInt.Length == num)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - num, "0.");
        if (computeStringInt.Length >= num)
            return (ComputeStringFloat)computeStringInt.Body.Insert(computeStringInt.Body.Length - num, ".");
        string str = (string)computeStringInt.Absolute();
        for (int length = str.Length; length < num; ++length)
            str = "0" + str;
        if (computeStringInt.IsPositive)
            return (ComputeStringFloat)str.Insert(0, "0.");
        return (ComputeStringFloat)str.Insert(0, "-0.");
    }

    public static ComputeStringFloat operator +(ComputeStringFloat left, object right)
    {
        return left + new ComputeStringFloat(right.ToString());
    }

    public static ComputeStringFloat operator +(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) + right;
    }

    public static ComputeStringFloat operator -(ComputeStringFloat left, object right)
    {
        return left - new ComputeStringFloat(right.ToString());
    }

    public static ComputeStringFloat operator -(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) - right;
    }

    public static ComputeStringFloat operator *(ComputeStringFloat left, object right)
    {
        return left * new ComputeStringFloat(right.ToString());
    }

    public static ComputeStringFloat operator *(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) * right;
    }

    public static ComputeStringFloat operator /(ComputeStringFloat left, object right)
    {
        return left / new ComputeStringFloat(right.ToString());
    }

    public static ComputeStringFloat operator /(object left, ComputeStringFloat right)
    {
        return new ComputeStringFloat(left.ToString()) / right;
    }

    public ComputeStringFloat Absolute()
    {
        if ((int)this.Body[0] == 43 || (int)this.Body[0] == 45)
            return new ComputeStringFloat(this.Body.Substring(1));
        return this;
    }

    public new string Trim(string numStr)
    {
        string str1 = numStr.Trim();
        if ((int)str1[0] == 43)
            str1 = str1.Substring(1);
        int num = str1.IndexOf('.');
        if (num >= 0)
        {
            for (int length = str1.Length - 1; length >= num; --length)
            {
                if ((int)str1[length] != 48)
                {
                    str1 = (int)str1[length] != 46 ? str1.Substring(0, length + 1) : str1.Substring(0, length);
                    break;
                }
            }
        }
        bool flag = false;
        string str2 = str1;
        string str3 = "";
        char ch;
        string[] strs = str2.Split('.');
        int lengths = 0;
        if (strs.Length > 1 && strs[1].Length > DividResaultPrecision)
        {
            lengths = strs[1].Length - DividResaultPrecision;
        }
        for (int index = 0; index < str2.Length - lengths; ++index)
        {
            if (flag)
            {
                string str4 = str3;
                ch = str2[index];
                string str5 = ch.ToString();
                str3 = str4 + str5;
            }
            else if ((int)str2[index] == 45)
            {
                string str4 = str3;
                ch = str2[index];
                string str5 = ch.ToString();
                str3 = str4 + str5;
            }
            else if ((int)str2[index] == 48)
            {
                if (index + 1 < str2.Length && (int)str2[index + 1] == 46 || index + 1 >= str2.Length)
                {
                    string str4 = str3;
                    ch = str2[index];
                    string str5 = ch.ToString();
                    str3 = str4 + str5;
                    flag = true;
                }
            }
            else
            {
                string str4 = str3;
                ch = str2[index];
                string str5 = ch.ToString();
                str3 = str4 + str5;
                flag = true;
            }
        }
        if (str3.Length == 2 && (int)str3[0] == 45 && (int)str3[1] == 48)
            str3 = "0";
        return str3;
    }

    public override string ToString()
    {
        return this.Body;
    }
    List<language> FigureStrs = new List<language>();
    public string ToFigureString()
    {
        if (FigureStrs.Count == 0)
        {
            languages Languages = DispositionManager.Instance.Languages;
            FigureStrs.Add(Languages.GetInfoToId(70101));
            FigureStrs.Add(Languages.GetInfoToId(70102));
            FigureStrs.Add(Languages.GetInfoToId(70103));
            FigureStrs.Add(Languages.GetInfoToId(70104));
            FigureStrs.Add(Languages.GetInfoToId(70105));
            FigureStrs.Add(Languages.GetInfoToId(70106));
            FigureStrs.Add(Languages.GetInfoToId(70107));
            FigureStrs.Add(Languages.GetInfoToId(70108));
            FigureStrs.Add(Languages.GetInfoToId(70109));
            FigureStrs.Add(Languages.GetInfoToId(70110));
            FigureStrs.Add(Languages.GetInfoToId(70111));
            FigureStrs.Add(Languages.GetInfoToId(70112));
            FigureStrs.Add(Languages.GetInfoToId(70113));
            FigureStrs.Add(Languages.GetInfoToId(70114));
            FigureStrs.Add(Languages.GetInfoToId(70115));
        }
        string[] strs = this.Body.Split('.');
        int index = -1;
        string Figure="";
        while (strs[0].Length > index * 3 || index == FigureStrs.Count) 
        {
            index++;
        }
        char[]  chars=  strs[0].ToCharArray();

        string n = "";
        for (int i = chars.Length - 1, l = 1; i >= 0; i--)
        {
            n = chars[i].ToString() + n;
            if (l > 0 && i > 0 && l % 3 == 0)
            {
                n = "." + n;
                l = 0;
            }
            l++;
        }
        string[] strss= n.Split('.');
        Figure = strss[0];
        if (strss.Length>=2)
        {
            Figure = strss[0] + "." + strss[1];
        }

        if (index>1)
        {
            return Figure+FigureStrs[index-2].language2;
        }
        else
        {
            return Figure;
        }
    }

        public ComputeStringInt ToComputeStringInt()
        {
            string numStr = this.IntPart;
            if (!this.IsPositive)
                numStr = numStr.Insert(0, "-");
            return new ComputeStringInt(numStr);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }