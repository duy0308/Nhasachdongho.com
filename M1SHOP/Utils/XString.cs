using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public static class XString
{
    public static String ToBase64(this String s)
    {
        var bytes = Encoding.Unicode.GetBytes(s);
        var ss = Convert.ToBase64String(bytes);
        return ss;
    }

    public static String FromBase64(this String s)
    {
        var bytes = Convert.FromBase64String(s);
        var ss = Encoding.Unicode.GetString(bytes);
        return ss;
    }

    public static String ToMD5(this String s)
    {
        var bytes = Encoding.Unicode.GetBytes(s);
        var bytesMD5 = MD5.Create().ComputeHash(bytes);
        var ss = Convert.ToBase64String(bytesMD5);
        return ss;
    }
    public static string EnCrypt(string strEnCrypt)// string key)
    {
        try
        {
            byte[] keyArr;
            byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
            MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
            keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes("sieuthikg"));//(key));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
            tripDes.Key = keyArr;
            tripDes.Mode = CipherMode.ECB;
            tripDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
            return Convert.ToBase64String(arrResult, 0, arrResult.Length);
        }
        catch (Exception ex) { }
        return "";
    }

    public static string DeCrypt(string strDecypt)//, string key)
    {
        try
        {
            byte[] keyArr;
            byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
            MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
            keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes("sieuthikg"));//(key));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
            tripDes.Key = keyArr;
            tripDes.Mode = CipherMode.ECB;
            tripDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
            return UTF8Encoding.UTF8.GetString(arrResult);
        }
        catch (Exception ex) { }
        return "";
    }
}