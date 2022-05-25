/*
 * Created by Akrosh Teotia
 *  
 * These are extension methods for c# to reuse in code inspite of rewriting again. Feel free to modify as per need.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtensionLibrary
{
    public static class LibExtensions
    {
        public static string Colored(this string strObj, Color color)
        {
            string temp = "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + "> " + strObj + "</color>";
            return temp;
        }

        public static int ToInt(this string strObj)
        {
            return int.Parse(strObj);
        }

        public static float ToFloat(this string strObj)
        {
            return float.Parse(strObj);
        }

        public static double ToDouble(this string strObj)
        {
            return double.Parse(strObj);
        }

        public static long ToLong(this string strObj)
        {
            return long.Parse(strObj);
        }

        public static bool ToBool(this string strObj)
        {
            return bool.Parse(strObj);
        }

        public static string FormatShrtNmbr(this string strObj, bool comaSeprated = false, bool inMillions = false)
        {
            if (strObj.ToLong() > 999 && strObj.ToLong() < 100000)
            {
                if (comaSeprated)
                {
                    return strObj.Substring(0, strObj.Length - 3) + "," + strObj.Substring(strObj.Length - 3);
                }
                else
                {
                    return strObj.Substring(0, strObj.Length - 3) + "," + strObj.Substring(strObj.Length - 3);
                }
            }

            if (inMillions)
            {
                if (strObj.ToLong() > 9999 && strObj.ToLong() < 1000000)
                {
                    if (comaSeprated)
                    {
                        return strObj.Substring(0, strObj.Length - 5) + "," + strObj.Substring(strObj.Length - 5, 2) + "," + strObj.Substring(strObj.Length - 3);
                    }
                    else
                    {
                        if (strObj[strObj.Length - 5] == '0')
                            return strObj.Substring(0, strObj.Length - 5) + "L";
                        else
                            return strObj.Substring(0, strObj.Length - 5) + "." + strObj.Substring(strObj.Length - 5, 1) + "L";
                    }
                }
                else
                {
                    if (strObj[strObj.Length - 6] == '0')
                        return strObj.Substring(0, strObj.Length - 6) + "M";
                    else
                        return strObj.Substring(0, strObj.Length - 6) + "." + strObj.Substring(strObj.Length - 6, 1) + "M";
                }
            }
            if (strObj.ToLong() > 9999 && strObj.ToLong() < 10000000)
            {
                if (comaSeprated)
                {
                    return strObj.Substring(0, strObj.Length - 5) + "," + strObj.Substring(strObj.Length - 5, 2) + "," + strObj.Substring(strObj.Length - 3);
                }
                else
                {
                    if (strObj[strObj.Length - 5] == '0')
                        return strObj.Substring(0, strObj.Length - 5) + "L";
                    else
                        return strObj.Substring(0, strObj.Length - 5) + "." + strObj.Substring(strObj.Length - 5, 1) + "L";
                }
            }

            if (strObj.ToLong() > 9999999)
            {
                if (strObj[strObj.Length - 7] == '0')
                    return strObj.Substring(0, strObj.Length - 7) + "Cr";
                else
                    return strObj.Substring(0, strObj.Length - 7) + "." + strObj.Substring(strObj.Length - 7, 1) + "Cr";
            }

            return strObj;
        }

        public static int IndexOf(this Enum obj) {
            return Array.IndexOf(Enum.GetValues(obj.GetType()), obj);
        }

        public static T EnumParse<T>(this Enum obj) {
            return (T)Enum.Parse(typeof(T),obj.ToString(),true);
        }
    }
}
