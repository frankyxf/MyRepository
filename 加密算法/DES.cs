﻿public class DESCode
{
	//默认私匙
	private const string CodeKey = "1a2s3d4f5g6h";

	//默认密钥向量
	private byte[] Keys = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };

	/// <summary>
	/// DES加密
	/// </summary>
	public string EncryptDES(string encryptString)
	{
		return EncryptDES(encryptString, CodeKey);
	}

	/// <summary>
	/// DES解密
	/// </summary>
	public string DecryptDES(string decryptString)
	{
		return DecryptDES(decryptString, CodeKey);
	}

	/// <summary>
	/// DES加密
	/// </summary>
	/// <param name="encryptString">待加密的字符串</param>
	/// <param name="encryptKey">加密密钥,要求为8位</param>
	/// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
	private string EncryptDES(string encryptString, string encryptKey)
	{
		try
		{
			byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
			byte[] rgbIV = Keys;
			byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
			DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
			MemoryStream mStream = new MemoryStream();
			CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
			cStream.Write(inputByteArray, 0, inputByteArray.Length);
			cStream.FlushFinalBlock();
			string str = Convert.ToBase64String(mStream.ToArray());
			return str;
		}
		catch
		{
			return encryptString;
		}
	}

	/// <summary>
	/// DES解密
	/// </summary>
	/// <param name="decryptString">待解密的字符串</param>
	/// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
	/// <returns>解密成功返回解密后的字符串，失败返源串</returns>
	private string DecryptDES(string decryptString, string decryptKey)
	{
		try
		{
			byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
			byte[] rgbIV = Keys;
			byte[] inputByteArray = Convert.FromBase64String(decryptString);
			DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
			MemoryStream mStream = new MemoryStream();
			CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
			cStream.Write(inputByteArray, 0, inputByteArray.Length);
			cStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(mStream.ToArray());
		}
		catch
		{
			return decryptString;
		}
	}
}
