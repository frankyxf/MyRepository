/// <summary>
/// 服务端，虚方法，默认TCP/IP连接
/// </summary>
/// <param name="server">服务IP地址</param>
/// <param name="port">服务端口</param>
/// <param name="encoding">报文编码</param>
protected virtual void Listener(String server, Int32 port, Encoding encoding)
{
	TcpListener bankServer = null;
	try
	{
		IPAddress localAddr = IPAddress.Parse(server);
		Log(String.Format("{0}\t正在{1}:{2}监听交易...",System.DateTime.Now, server, port));
		bankServer = new TcpListener(localAddr, port);
		bankServer.Start();

		while (true)
		{
			TcpClient client = bankServer.AcceptTcpClient();
			try
			{

				NetworkStream stream = client.GetStream();
				List<byte> byteData = new List<byte>();
				int intLength = 0;
				do
				{
					byte[] buffer = new byte[1024];
					intLength = stream.Read(buffer, 0, buffer.Length);
					if (intLength > 0)
					{
						byteData.AddRange(buffer);
					}
				} while (intLength == 1024);

				if (byteData.Count > 0)
					byteData.RemoveRange(byteData.Count - (1024 - intLength), 1024 - intLength);

				Byte[] requests = byteData.ToArray();
				Log(String.Format("{0}\t收到: {1}",System.DateTime.Now,encoding.GetString(requests, 0, requests.Length)));
				Byte[] responses = Response(requests);

				Log(String.Format("{0}\t响应: {1}",System.DateTime.Now,encoding.GetString(responses, 0, responses.Length)));
				stream.Write(responses, 0, responses.Length);

			}
			catch (Exception e)
			{
				Log(String.Format("{0}\t{1}",System.DateTime.Now ,e.Message));
			}
			finally
			{
				if (client != null)
				{
					client.Close();
				}
			}
		}
	}
	catch (Exception ex)
	{
		Log(String.Format("{0}\t{1}", System.DateTime.Now, ex.Message));
	}
	finally
	{
		if (bankServer != null)
		{
			bankServer.Stop();
		}
	}
}