        /// <summary>
        /// 获取标记(反序列化)
        /// </summary>
        /// <typeparam name="T">标记类型</typeparam>
        /// <param name="filePath">标记文件路径</param>
        /// <returns>标记</returns>
        public static T Deserialize<T>(String filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// 标记序列化到磁盘文件
        /// </summary>
        /// <typeparam name="T">标记类型</typeparam>
        /// <param name="t">具体标记</param>
        /// <param name="filePath">标记文件路径</param>
        public static void Serializer<T>(T t, String filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, t);
            }
        }