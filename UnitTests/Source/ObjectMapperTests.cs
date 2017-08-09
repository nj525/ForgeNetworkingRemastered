﻿using BeardedManStudios;
using BeardedManStudios.Forge.Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class ObjectMapperTests : BaseTest
	{
		[TestMethod]
		public void TestObjectMapper()
		{
			BMSByte data = new BMSByte();
			Write(data);
			Read(data);
		}

		public void Write(BMSByte data)
		{
			ObjectMapper.Instance.MapBytes(data, (sbyte)1);
			ObjectMapper.Instance.MapBytes(data, (byte)2);
			ObjectMapper.Instance.MapBytes(data, (short)3);
			ObjectMapper.Instance.MapBytes(data, (ushort)4);
			ObjectMapper.Instance.MapBytes(data, (int)5);
			ObjectMapper.Instance.MapBytes(data, (uint)6);
			ObjectMapper.Instance.MapBytes(data, (long)7);
			ObjectMapper.Instance.MapBytes(data, (ulong)8);
			ObjectMapper.Instance.MapBytes(data, (float)9.93f);
			ObjectMapper.Instance.MapBytes(data, (double)99.369);
			ObjectMapper.Instance.MapBytes(data, 'F');
			ObjectMapper.Instance.MapBytes(data, "Forge Networking");

			byte[] tmp = new byte[11];
			for (byte i = 10; i < 21; i++)
				tmp[i - 10] = i;

			ObjectMapper.Instance.MapBytes(data, tmp);
		}

		public void Read(BMSByte data)
		{
			Assert.AreEqual((sbyte)1, ObjectMapper.Instance.Map<sbyte>(data));
			Assert.AreEqual((byte)2, ObjectMapper.Instance.Map<byte>(data));
			Assert.AreEqual((short)3, ObjectMapper.Instance.Map<short>(data));
			Assert.AreEqual((ushort)4, ObjectMapper.Instance.Map<ushort>(data));
			Assert.AreEqual((int)5, ObjectMapper.Instance.Map<int>(data));
			Assert.AreEqual((uint)6, ObjectMapper.Instance.Map<uint>(data));
			Assert.AreEqual((long)7, ObjectMapper.Instance.Map<long>(data));
			Assert.AreEqual((ulong)8, ObjectMapper.Instance.Map<ulong>(data));
			Assert.AreEqual((float)9.93f, ObjectMapper.Instance.Map<float>(data));
			Assert.AreEqual((double)99.369, ObjectMapper.Instance.Map<double>(data));
			Assert.AreEqual('F', ObjectMapper.Instance.Map<char>(data));
			Assert.AreEqual("Forge Networking", ObjectMapper.Instance.Map<string>(data));

			byte[] tmp = ObjectMapper.Instance.Map<byte[]>(data);
			for (int i = 10; i < 21; i++)
				Assert.AreEqual(i, tmp[i - 10]);
		}
	}
}