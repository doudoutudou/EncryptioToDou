using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class TuDouDLL
{
    //声明需要从dll中导入的函数，我的dll名称为：TuDou 。这个DllImport的使用也有很多参数，在官方文档中可以查到
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern bool __Test(bool isbool);
    
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern byte __Test2(byte _byte);
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern byte __Test3(byte _byte);
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern IntPtr __Test4(byte[] byte_encode,int byte_len);
    
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern IntPtr __Encode(byte[] byte_encode,int len);
    [DllImport("DouDll.dll", SetLastError = true)]
    public static extern IntPtr __Decode(byte[] byte_decode,int len);

    public static byte[] Test4(byte[] byte_encode)
    {
        int len = byte_encode.Length;
        IntPtr intPtr = __Test4(byte_encode,1);
        
        byte[] bytes = new byte[len];
        Marshal.Copy(intPtr, bytes, 0, bytes.Length);
        //byte[] _byte =new byte[1920 * 1080 * 4];
        //Marshal.Copy(_byte, 0, intPtr, 1920 * 1080 * 4);
        //string m_strAddrName = Marshal.PtrToStringAnsi(intPtr);//将其转换为字符串
        //byte[] bytes = Encoding.UTF8.GetBytes(m_strAddrName);
        return bytes;
    }

    //加密
    public static byte[] Encode(byte[] byte_encode2,string key,bool isClone =false)
    {
        byte[] byte_encode;
        if (isClone)
        {
            byte_encode = byte_encode2.Clone() as byte[];
        }
        else
        {
            byte_encode = byte_encode2;
        }


        int len = byte_encode.Length;
        IntPtr intPtr = __Encode(byte_encode,len);
        
        byte[] bytes = new byte[len];
        Marshal.Copy(intPtr, bytes, 0, bytes.Length);
        return bytes;
    }
    //解密
    public static byte[] Decode(byte[] byte_decode2,string key,bool isClone =false)
    {
        byte[] byte_decode;
        if (isClone)
        {
            byte_decode = byte_decode2.Clone() as byte[];
        }
        else
        {
            byte_decode = byte_decode2;
        }
        

        int len = byte_decode.Length;
        IntPtr intPtr = __Decode(byte_decode,len);
        
        byte[] bytes = new byte[len];
        Marshal.Copy(intPtr, bytes, 0, bytes.Length);
        return bytes;
    }
}
