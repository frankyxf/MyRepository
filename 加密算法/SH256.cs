private static string Sha2Encrypt(string str)
{
	var mySha256 = SHA256.Create();
	mySha256.ComputeHash(Encoding.UTF8.GetBytes(str));

	// 获取消息摘要
	var hash = BitConverter.ToString(mySha256.Hash);

	// 用私钥对消息摘要进行加密
	return new DESCode().EncryptDES(hash);
}