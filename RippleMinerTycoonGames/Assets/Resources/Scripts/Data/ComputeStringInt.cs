using System;

    public class ComputeStringInt
    {
        public string Body = "0";

        public static readonly ComputeStringInt Zero = new ComputeStringInt("0");

        public int Length
        {
            get
            {
                if ((int)this.Body[0] == 43 || (int)this.Body[0] == 45)
                    return this.Body.Length - 1;
                return this.Body.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                if ((int)this.Body[0] == 43 || (int)this.Body[0] == 45)
                    return (int)this.Body[index + 1] - 48;
                return (int)this.Body[index] - 48;
            }
        }

        public bool IsPositive
        {
            get
            {
                return (int)this.Body[0] != 45 || !(new ComputeStringInt(this.Body.Substring(1)) != (ComputeStringInt)0L);
            }
        }

        public ComputeStringInt()
        {
        }

        public ComputeStringInt(string numStr)
        {
            if (string.IsNullOrEmpty(numStr))
                this.Body = "0";
            else
                this.Body = this.Trim(numStr);
        }

        public static implicit operator string(ComputeStringInt source)
        {
            return source.Body;
        }

        public static implicit operator ComputeStringInt(long real)
        {
            return new ComputeStringInt(real.ToString());
        }

        public static implicit operator ComputeStringInt(string real)
        {
            return new ComputeStringInt(real);
        }

        public static bool operator >(ComputeStringInt left, ComputeStringInt right)
        {
            if (left.IsPositive && !right.IsPositive && left.Absolute().Body != "0" && right.Absolute().Body != "0")
                return true;
            if (left.IsPositive && right.IsPositive)
            {
                if (left.Length > right.Length)
                    return true;
                if (left.Length != right.Length)
                    return false;
                for (int index = 0; index < left.Length; ++index)
                {
                    if (left[index] > right[index])
                        return true;
                    if (left[index] < right[index])
                        return false;
                }
            }
            else if (!left.IsPositive && !right.IsPositive)
            {
                if (left.Length < right.Length)
                    return true;
                if (left.Length != right.Length)
                    return false;
                for (int index = 0; index < left.Length; ++index)
                {
                    if (left[index] < right[index])
                        return true;
                    if (left[index] > right[index])
                        return false;
                }
            }
            else if (left.IsPositive && !right.IsPositive && (left.Absolute().Body == "0" && right.Absolute().Body != "0" || left.Absolute().Body != "0" && right.Absolute().Body == "0"))
                return true;
            return false;
        }

        public static bool operator <(ComputeStringInt left, ComputeStringInt right)
        {
            return right > left;
        }

        public static bool operator >=(ComputeStringInt left, ComputeStringInt right)
        {
            return left > right || left == right;
        }

        public static bool operator <=(ComputeStringInt left, ComputeStringInt right)
        {
            return left < right || left == right;
        }

        public static bool operator ==(ComputeStringInt left, ComputeStringInt right)
        {
            return !(left > right) && !(left < right);
        }

        public static bool operator !=(ComputeStringInt left, ComputeStringInt right)
        {
            return left > right || left < right;
        }

        public static bool operator >(ComputeStringInt left, object right)
        {
            return left > new ComputeStringInt(right.ToString());
        }

        public static bool operator >(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) > right;
        }

        public static bool operator <(ComputeStringInt left, object right)
        {
            return left < new ComputeStringInt(right.ToString());
        }

        public static bool operator <(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) < right;
        }

        public static bool operator >=(ComputeStringInt left, object right)
        {
            return left >= new ComputeStringInt(right.ToString());
        }

        public static bool operator >=(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) >= right;
        }

        public static bool operator <=(ComputeStringInt left, object right)
        {
            return left <= new ComputeStringInt(right.ToString());
        }

        public static bool operator <=(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) <= right;
        }

        public static bool operator ==(ComputeStringInt left, object right)
        {
            return left == new ComputeStringInt(right.ToString());
        }

        public static bool operator ==(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) == right;
        }

        public static bool operator !=(ComputeStringInt left, object right)
        {
            return left != new ComputeStringInt(right.ToString());
        }

        public static bool operator !=(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) != right;
        }

        public static ComputeStringInt operator +(ComputeStringInt left, ComputeStringInt right)
        {
            ComputeStringInt computeStringInt1 = new ComputeStringInt();
            if (left.IsPositive && right.IsPositive)
            {
                int length = right.Length;
                if (left.Length > right.Length)
                    length = left.Length;
                int num1 = 0;
                for (int index = 0; index < length; ++index)
                {
                    int num2 = index >= left.Length || index >= right.Length ? (index < left.Length ? (index < right.Length ? 0 : left[left.Length - 1 - index] + num1) : right[right.Length - 1 - index] + num1) : left[left.Length - 1 - index] + right[right.Length - 1 - index] + num1;
                    num1 = num2 / 10;
                    int num3;
                    if (index == 0)
                    {
                        ComputeStringInt computeStringInt2 = computeStringInt1;
                        num3 = num2 % 10;
                        string str = num3.ToString();
                        computeStringInt2.Body = str;
                    }
                    else
                    {
                        ComputeStringInt computeStringInt2 = computeStringInt1;
                        string str1 = computeStringInt1.Body;
                        int startIndex = 0;
                        num3 = num2 % 10;
                        string str2 = num3.ToString();
                        string str3 = str1.Insert(startIndex, str2);
                        computeStringInt2.Body = str3;
                    }
                }
                computeStringInt1.Body = computeStringInt1.Body.Insert(0, num1.ToString());
            }
            else if (left.IsPositive && !right.IsPositive)
                computeStringInt1 = left - new ComputeStringInt((string)right.Absolute());
            else if (!left.IsPositive && right.IsPositive)
                computeStringInt1 = right - new ComputeStringInt((string)left.Absolute());
            else if (!left.IsPositive && !right.IsPositive)
                computeStringInt1 = left - new ComputeStringInt((string)right.Absolute());
            computeStringInt1.Trim();
            return computeStringInt1;
        }

        public static ComputeStringInt operator -(ComputeStringInt left, ComputeStringInt right)
        {
            ComputeStringInt computeStringInt = new ComputeStringInt();
            if (left == right)
                return new ComputeStringInt("0");
            if (left > ComputeStringInt.Zero && right == ComputeStringInt.Zero)
                return left;
            if (left == ComputeStringInt.Zero && right < ComputeStringInt.Zero)
                return new ComputeStringInt((string)right.Absolute());
            if (left == ComputeStringInt.Zero && right > ComputeStringInt.Zero)
                return new ComputeStringInt(right.Body.Insert(0, "-"));
            if (left > ComputeStringInt.Zero && right > ComputeStringInt.Zero)
            {
                if (left > right)
                {
                    int num1 = 0;
                    for (int index = 0; index < left.Length; ++index)
                    {
                        int num2 = index >= left.Length || index >= right.Length ? (index < right.Length ? 0 : left[left.Length - 1 - index] - num1) : left[left.Length - 1 - index] - right[right.Length - 1 - index] - num1;
                        num1 = num2 / 10;
                        if (num2 < 0)
                        {
                            num1 = 1;
                            num2 = 10 + num2;
                        }
                        computeStringInt.Body = index != 0 ? computeStringInt.Body.Insert(0, num2.ToString()) : num2.ToString();
                    }
                }
                else if (left < right)
                {
                    computeStringInt = right - left;
                    computeStringInt.Body = computeStringInt.Body.Insert(0, "-");
                }
            }
            else if (left < ComputeStringInt.Zero && right < ComputeStringInt.Zero)
                computeStringInt = new ComputeStringInt((string)right.Absolute()) - new ComputeStringInt((string)left.Absolute());
            else if (left > ComputeStringInt.Zero && right < ComputeStringInt.Zero)
                computeStringInt = left + new ComputeStringInt((string)right.Absolute());
            else if (left < ComputeStringInt.Zero && right > ComputeStringInt.Zero)
            {
                computeStringInt = new ComputeStringInt((string)left.Absolute()) + right;
                computeStringInt.Body = computeStringInt.Body.Insert(0, "-");
            }
            computeStringInt.Trim();
            return computeStringInt;
        }

        public static ComputeStringInt operator *(ComputeStringInt left, ComputeStringInt right)
        {
            ComputeStringInt computeStringInt = new ComputeStringInt();
            if (left == ComputeStringInt.Zero || right == ComputeStringInt.Zero)
                return ComputeStringInt.Zero;
            if (left.IsPositive && right.IsPositive)
            {
                for (int index1 = right.Length - 1; index1 >= 0; --index1)
                {
                    int num1 = 0;
                    string numStr = "";
                    for (int index2 = left.Length - 1; index2 >= 0; --index2)
                    {
                        int num2 = right.Absolute()[index1] * left.Absolute()[index2] + num1;
                        numStr = numStr.Insert(0, (num2 % 10).ToString());
                        num1 = num2 / 10;
                    }
                    if ((uint)num1 > 0U)
                        numStr = numStr.Insert(0, num1.ToString());
                    for (int index2 = 0; index2 < right.Length - 1 - index1; ++index2)
                        numStr += "0";
                    computeStringInt += new ComputeStringInt(numStr);
                }
            }
            else if (!left.IsPositive && right.IsPositive || left.IsPositive && !right.IsPositive)
            {
                computeStringInt = new ComputeStringInt((string)left.Absolute()) * new ComputeStringInt((string)right.Absolute());
                computeStringInt.Body = computeStringInt.Body.Insert(0, "-");
            }
            else if (!left.IsPositive && !right.IsPositive)
                computeStringInt = new ComputeStringInt((string)left.Absolute()) * new ComputeStringInt((string)right.Absolute());
            computeStringInt.Trim();
            return computeStringInt;
        }

        public static ComputeStringInt operator /(ComputeStringInt left, ComputeStringInt right)
        {
            ComputeStringInt computeStringInt1 = new ComputeStringInt();
            if (right == ComputeStringInt.Zero)
                throw new Exception("³ýÁã´íÎó£¡");
            if (left == ComputeStringInt.Zero)
                return ComputeStringInt.Zero;
            if (right == new ComputeStringInt("1"))
                return left;
            if (left.IsPositive && right.IsPositive)
            {
                if (left < right)
                {
                    computeStringInt1 = ComputeStringInt.Zero;
                }
                else
                {
                    string numStr = "";
                    ComputeStringInt computeStringInt2 = new ComputeStringInt(left.Body.Substring(0, right.Length - 1));
                    for (int index = right.Length - 1; index < left.Length; ++index)
                    {
                        computeStringInt2 = computeStringInt2 * new ComputeStringInt("10") + new ComputeStringInt(left[index].ToString());
                        computeStringInt2.Trim();
                        int num = 0;
                        for (num = 0; num < 10; ++num)
                        {
                            ComputeStringInt computeStringInt3 = right * new ComputeStringInt(num.ToString());
                            if (computeStringInt3 > computeStringInt2)
                            {
                                numStr += (num - 1);
                                computeStringInt2 -= right * new ComputeStringInt((num - 1).ToString());
                                break;
                            }
                            if (computeStringInt3 == computeStringInt2)
                            {
                                numStr += num;
                                computeStringInt2 = ComputeStringInt.Zero;
                                break;
                            }
                        }
                        if (num == 10)
                        {
                            numStr += (num - 1);
                            computeStringInt2 -= right * new ComputeStringInt((num - 1).ToString());
                        }
                    }
                    computeStringInt1 = new ComputeStringInt(numStr);
                }
            }
            else if (!left.IsPositive && right.IsPositive || left.IsPositive && !right.IsPositive)
            {
                computeStringInt1 = new ComputeStringInt((string)left.Absolute()) / new ComputeStringInt((string)right.Absolute());
                computeStringInt1.Body = computeStringInt1.Body.Insert(0, "-");
            }
            else if (!left.IsPositive && !right.IsPositive)
                computeStringInt1 = new ComputeStringInt((string)left.Absolute()) / new ComputeStringInt((string)right.Absolute());
            computeStringInt1.Trim();
            return computeStringInt1;
        }

        public static ComputeStringInt operator %(ComputeStringInt left, ComputeStringInt right)
        {
            ComputeStringInt computeStringInt1 = new ComputeStringInt();
            ComputeStringInt computeStringInt2 = left - left / right * right;
            computeStringInt2.Trim();
            return computeStringInt2;
        }

        public static ComputeStringInt operator +(ComputeStringInt left, object right)
        {
            return left + new ComputeStringInt(right.ToString());
        }

        public static ComputeStringInt operator +(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) + right;
        }

        public static ComputeStringInt operator -(ComputeStringInt left, object right)
        {
            return left - new ComputeStringInt(right.ToString());
        }

        public static ComputeStringInt operator -(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) - right;
        }

        public static ComputeStringInt operator *(ComputeStringInt left, object right)
        {
            return left * new ComputeStringInt(right.ToString());
        }

        public static ComputeStringInt operator *(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) * right;
        }

        public static ComputeStringInt operator /(ComputeStringInt left, object right)
        {
            return left / new ComputeStringInt(right.ToString());
        }

        public static ComputeStringInt operator /(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) / right;
        }

        public static ComputeStringInt operator %(ComputeStringInt left, object right)
        {
            return left % new ComputeStringInt(right.ToString());
        }

        public static ComputeStringInt operator %(object left, ComputeStringInt right)
        {
            return new ComputeStringInt(left.ToString()) % right;
        }

        public ComputeStringInt Absolute()
        {
            if ((int)this.Body[0] == 43 || (int)this.Body[0] == 45)
                return new ComputeStringInt(this.Body.Substring(1));
            return this;
        }

        public void Trim()
        {
            this.Body = this.Trim(this.Body);
        }

        public string Trim(string numStr)
        {
            string str1 = numStr.Trim();
            if ((int)str1[0] == 43)
                str1 = str1.Substring(1);
            string str2 = str1;
            if ((int)str1[0] == 45)
                str2 = str1.Substring(1);
            int index = 0;
            while (index < str2.Length && (int)str2[index] == 48)
                ++index;
            if (index == str2.Length)
                return "0";
            bool flag = true;
            if ((int)str1[0] == 45)
                flag = false;
            int startIndex = 0;
            while (startIndex < str2.Length && (int)str2[startIndex] == 48)
                ++startIndex;
            string str3 = str2.Substring(startIndex);
            if (!flag)
                str3 = str3.Insert(0, "-");
            return str3;
        }

        public override string ToString()
        {
            return this.Body;
        }

        public ComputeStringFloat ToComputeStringFloat()
        {
            return new ComputeStringFloat(this.Body);
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