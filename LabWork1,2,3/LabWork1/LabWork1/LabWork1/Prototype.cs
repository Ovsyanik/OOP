using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace LabWork1
{
    
    public abstract class Prototype<T>
    {
        //Поверхностное копирование
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }

        //Глубокое копирование
        public virtual T DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var context = new StreamingContext(StreamingContextStates.Clone);
                BinaryFormatter formatter = new BinaryFormatter { Context = context };
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
