namespace LuresWebLib
{
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;

    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly string fileToSave;

        protected BaseRepository(string fileToSave)
        {
            this.fileToSave = fileToSave;
        }

        public virtual void Save(T listToSave)
        {
            var writer = new XmlSerializer(typeof(T));
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data//" + fileToSave;
            Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data//");
            var file = File.Create(path);
            writer.Serialize(file, listToSave);
            file.Close();
        }

        public virtual T Load()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data//" + fileToSave;
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format("Can't find {0}", path));
            }
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}